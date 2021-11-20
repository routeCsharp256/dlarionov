using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    /// <summary>
    /// Мерч
    /// </summary>
    public class Merch : Entity
    {
        public Merch(Sku sku, string name, MerchType type)
        {
            Sku = sku;
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Идентификатор товара 
        /// </summary>
        public Sku Sku { get; }

        /// <summary>
        /// Наименование мерча
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Тип мерча
        /// </summary>
        public MerchType Type { get; }
    }
}
