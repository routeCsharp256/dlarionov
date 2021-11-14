using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    public class Merch : Entity
    {
        public Sku Sku { get; }
        public string Name { get; }
        public MerchType Type { get; }

        public Merch(Sku sku, string name, MerchType type)
        {
            Sku = sku;
            Name = name;
            Type = type;
        }
    }
}
