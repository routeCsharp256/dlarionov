using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    /// <summary>
    /// Статус заявки
    /// </summary>
    public class ApplicationStatus : Enumeration
    {
        /// <summary>
        /// Заявка создана
        /// </summary>
        public static ApplicationStatus Created = new(1,nameof(Created));
        
        /// <summary>
        /// Заявка в очереди, на складе нет необходимой позиции
        /// </summary>
        public static ApplicationStatus InQueue = new(2, nameof(InQueue));
        
        /// <summary>
        /// Сотрудник получил мерч
        /// </summary>
        public static ApplicationStatus Reserved = new(3, nameof(Reserved));
        
        /// <summary>
        /// Заявка отменена
        /// </summary>
        public static ApplicationStatus Cancelled = new(4, nameof(Cancelled));
        
        /// <summary>
        /// Ожидает получения сотрудником мерча
        /// </summary>
        public static ApplicationStatus ReceiveWaiting = new(5, nameof(ReceiveWaiting));

        public ApplicationStatus(int id, string name) : base(id, name)
        {
        }
    }
}
