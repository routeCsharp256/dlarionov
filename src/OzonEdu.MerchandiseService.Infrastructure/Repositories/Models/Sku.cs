namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Models
{
    public class Sku
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int ItemTypeId { get; set; }

        public int ClothingSize { get; set; }
    }
}