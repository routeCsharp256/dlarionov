using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    /// <summary>
    /// Тип мерча
    /// </summary>
    public class MerchType : Enumeration
    {
        /// <summary>
        /// Одежда
        /// </summary>
        public static MerchType Сlothing = new(1, nameof(Сlothing));
        
        /// <summary>
        /// Аксессуар
        /// </summary>
        public static MerchType Accessory = new(2, nameof(Accessory));
        
        /// <summary>
        /// Канцтовар
        /// </summary>
        public static MerchType Stationery = new(3, nameof(Stationery));
        
        /// <summary>
        /// Другое
        /// </summary>
        public static MerchType Other = new(4, nameof(Other));

        public MerchType(int id, string name) : base(id, name)
        {
        }
    }
}
