using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate;

namespace OzonEdu.MerchandiseService.Domain.Events.MerchReceiptApplicationAggregate
{
    /// <summary>
    /// Заявка на получение мерча отменена
    /// </summary>
    public class MerchReceiptApplicationDeclined : INotification
    {
        /// <summary>
        /// Номер заявки
        /// </summary>
        public ReceiptNumber ReceiptNumber { get; }

        public MerchReceiptApplicationDeclined(ReceiptNumber receiptNumber)
        {
            ReceiptNumber = receiptNumber;
        }
    }
}