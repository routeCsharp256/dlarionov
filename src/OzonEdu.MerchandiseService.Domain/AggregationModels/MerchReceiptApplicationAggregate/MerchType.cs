using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    public class MerchType : Enumeration
    {
        public static MerchType Сlothing = new(1, nameof(Сlothing));
        public static MerchType Accessory = new(2, nameof(Accessory));
        public static MerchType Stationery = new(3, nameof(Stationery));
        public static MerchType Other = new(4, nameof(Other));

        public MerchType(int id, string name) : base(id, name)
        {
        }
    }
}
