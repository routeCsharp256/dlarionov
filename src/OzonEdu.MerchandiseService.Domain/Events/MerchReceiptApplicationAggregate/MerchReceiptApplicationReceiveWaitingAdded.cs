using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate;

namespace OzonEdu.MerchandiseService.Domain.Events.MerchReceiptApplicationAggregate
{
    /// <summary>
    /// Зарезервирован на складе. Ожидает получателя.
    /// </summary>
    public class MerchReceiptApplicationReceiveWaitingAdded : INotification
    {
        /// <summary>
        /// Номер заявки
        /// </summary>
        public ReceiptNumber ReceiptNumber { get; }

        public MerchReceiptApplicationReceiveWaitingAdded(ReceiptNumber receiptNumber)
        {
            ReceiptNumber = receiptNumber;
        }
    }
}