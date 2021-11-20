using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate;

namespace OzonEdu.MerchandiseService.Domain.Events.MerchReceiptApplicationAggregate
{
    /// <summary>
    /// Заявка добавлена в очередь. Нет нужного мерча на складе.
    /// </summary>
    public class MerchReceiptApplicationInQueueAdded : INotification
    {
        /// <summary>
        /// Номер заявки
        /// </summary>
        public ReceiptNumber ReceiptNumber { get; }

        public MerchReceiptApplicationInQueueAdded(ReceiptNumber receiptNumber)
        {
            ReceiptNumber = receiptNumber;
        }
    }
}