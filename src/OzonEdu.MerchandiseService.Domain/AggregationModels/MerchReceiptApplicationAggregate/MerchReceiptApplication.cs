using System;
using System.Collections.Generic;
using System.Linq;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Events.MerchReceiptApplicationAggregate;
using OzonEdu.MerchandiseService.Domain.Exceptions.MerchReceiptApplicationAggregate;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    /// <summary>
    /// Заявка на получение набора мерча
    /// </summary>
    public class MerchReceiptApplication : Entity, IAggregationRoot
    {
        public MerchReceiptApplication(ReceiptNumber receiptNumber,
            Employee employee,
            MerchPack merchPack,
            ApplicationStatus status,
            Date createdAt,
            Date giveOutAt)
        {
            ReceiptNumber = receiptNumber;
            Employee = employee;
            MerchPack = merchPack;
            ApplicationStatus = status;
            CreatedAt = createdAt;
            GiveOutAt = giveOutAt;
        }

        /// <summary>
        /// Номер заявки
        /// </summary>
        public ReceiptNumber ReceiptNumber { get; }

        /// <summary>
        /// Сотрудник
        /// </summary>
        public Employee Employee { get; }

        /// <summary>
        /// Набор мерча
        /// </summary>
        public MerchPack MerchPack { get; }

        /// <summary>
        /// Статус заявки
        /// </summary>
        public ApplicationStatus ApplicationStatus { get; private set; }

        /// <summary>
        /// Дата создания заявки
        /// </summary>
        public Date CreatedAt { get; }

        /// <summary>
        /// Дата выдачи мерча
        /// </summary>
        public Date? GiveOutAt { get; private set; }

        private MerchReceiptApplication(Employee employee,
            MerchPack merchPack,
            Date createdAt)
        {
            Employee = employee;
            MerchPack = merchPack;
            ApplicationStatus = ApplicationStatus.Created;
            CreatedAt = createdAt;
        }

        public static MerchReceiptApplication Create(Employee employee,
            MerchPack merchPack,
            Date createdAt,
            IReadOnlyCollection<MerchReceiptApplication> alreadyExistedRequests, bool isExchange = false)
        {
            var newMerchReceiptApplication = new MerchReceiptApplication(employee, merchPack, createdAt);

            if (!newMerchReceiptApplication.CheckAbilityToGiveOut(alreadyExistedRequests, merchPack, createdAt, isExchange))
            {
                throw new MerchReceiptApplicationCheckAbilityException("Current merch pack is not ability to give out");
            }

            return newMerchReceiptApplication;
        }

        /// <summary>
        /// Выдача мерча
        /// </summary>
        /// <param name="isAvailableToGiveOut"></param>
        /// <param name="giveOutAt"></param>
        public void GiveOut(bool isAvailableToGiveOut, Date giveOutAt)
        {
            if (Equals(ApplicationStatus, ApplicationStatus.Created)
                || Equals(ApplicationStatus, ApplicationStatus.InQueue))
            {
                if (isAvailableToGiveOut)
                {
                    ApplicationStatus = ApplicationStatus.ReceiveWaiting;
                    GiveOutAt = giveOutAt;

                    AddReceiveWaitingDomainEvent(ReceiptNumber);
                }
                else
                {
                    ApplicationStatus = ApplicationStatus.InQueue;

                    AddToQueueDomainEvent(ReceiptNumber);
                }
            }
            else
            {
                throw new MerchReceiptApplicationGiveOutException(
                    $"Unable to give out merch pack with '{ApplicationStatus}' application status");
            }
        }

        /// <summary>
        /// Отклонение выдачи мерча
        /// </summary>
        public void Decline()
        {
            if (Equals(ApplicationStatus, ApplicationStatus.Reserved)
                || Equals(ApplicationStatus, ApplicationStatus.Cancelled))
            {
                throw new MerchReceiptApplicationDeclineException(
                    $"Unable to decline current merch receipt application with '{ApplicationStatus}' application status");
            }

            ApplicationStatus = ApplicationStatus.Cancelled;
            DeclineDomainEvent(ReceiptNumber);
        }

        /// <summary>
        /// Проверка, что заявка соответствует требованиям для выдачи
        /// </summary>
        /// <param name="alreadyExistedRequests"></param>
        /// <param name="merchPack"></param>
        /// <param name="createdAt"></param>
        /// <param name="isExchange"></param>
        /// <returns></returns>
        private bool CheckAbilityToGiveOut(IReadOnlyCollection<MerchReceiptApplication> alreadyExistedRequests,
            MerchPack merchPack,
            Date createdAt,
            bool isExchange)
        {
            var currentPackNotCancelledRequests = alreadyExistedRequests
                .Where(x => !Equals(x.ApplicationStatus, ApplicationStatus.Cancelled)
                            && Equals(x.MerchPack, MerchPack))
                .ToArray();

            if (currentPackNotCancelledRequests.Length > 0)
            {
                if (isExchange)
                {
                    //TODO: если больше года - выдать
                    return false;
                }

                return false;
            }

            return true;
        }

        public void SetGiveOutAt(Date giveOutAt)
        {
            if (CreatedAt.Value.Date > giveOutAt.Value.Date)
            {
                throw new ArgumentException($"'{nameof(GiveOutAt)}' value must be greater or equal '{nameof(CreatedAt)}' value");
            }

            GiveOutAt = giveOutAt;
        }

        /// <summary>
        /// Какого-то мерча нет на складе. Заявка добавлена в очередь.
        /// </summary>
        /// <param name="receiptNumber"></param>
        private void AddToQueueDomainEvent(ReceiptNumber receiptNumber)
        {
            var addToQueueDomainEvent = new MerchReceiptApplicationInQueueAdded(receiptNumber);
            AddDomainEvent(addToQueueDomainEvent);
        }

        /// <summary>
        /// Мерч зарезервирован. Ожидает получения сотрудником.
        /// </summary>
        /// <param name="receiptNumber"></param>
        private void AddReceiveWaitingDomainEvent(ReceiptNumber receiptNumber)
        {
            var addReceiveWaitingDomainEvent = new Events.MerchReceiptApplicationAggregate.MerchReceiptApplicationReceiveWaitingAdded(receiptNumber);
            AddDomainEvent(addReceiveWaitingDomainEvent);
        }

        /// <summary>
        /// Отмена заявки
        /// </summary>
        /// <param name="receiptNumber"></param>
        private void DeclineDomainEvent(ReceiptNumber receiptNumber)
        {
            var declineDomainEvent = new MerchReceiptApplicationDeclined(receiptNumber);
            AddDomainEvent(declineDomainEvent);
        }
    }
}
