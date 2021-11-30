namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Models
{
    public class StockItem
    {
        public long Id { get; set; }

        public long SkuId { get; set; }

        public int Quantity { get; set; }

        public int MinimalQuantity { get; set; }
    }
}