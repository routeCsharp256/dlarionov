using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptRequestAggregate
{
    public class RequestStatus : Enumeration
    {
        /// <summary>
        /// Запрос создан
        /// </summary>
        public static RequestStatus Created = new(1, nameof(Created));

        /// <summary>
        /// Запрос в процессе
        /// </summary>
        public static RequestStatus Processed = new(2, nameof(Processed));

        /// <summary>
        /// Запрос выполнен успешно
        /// </summary>
        public static RequestStatus Successful = new(3, nameof(Successful));

        /// <summary>
        /// Запрос отклонён
        /// </summary>
        public static RequestStatus Declined = new(4, nameof(Declined));


        public RequestStatus(int id, string name) : base(id, name)
        {
        }
    }
}