using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    /// <summary>
    /// Статус заявки
    /// </summary>
    public class ApplicationStatus : Enumeration
    {
        public static ApplicationStatus InQueue = new(1, nameof(InQueue));
        public static ApplicationStatus Reserved = new(2, nameof(Reserved));
        public static ApplicationStatus Cancelled = new(3, nameof(Cancelled));
        public static ApplicationStatus ReceiveWaiting = new(4, nameof(ReceiveWaiting));

        public ApplicationStatus(int id, string name) : base(id, name)
        {
        }
    }
}
