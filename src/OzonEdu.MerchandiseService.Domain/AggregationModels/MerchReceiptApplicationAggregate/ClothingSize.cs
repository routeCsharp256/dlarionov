using System;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    /// <summary>
    /// Размер одежды
    /// </summary>
    public class ClothingSize : Enumeration
    {
        public static ClothingSize XS = new(1, nameof(XS));
        public static ClothingSize S = new(2, nameof(S));
        public static ClothingSize M = new(3, nameof(M));
        public static ClothingSize L = new(4, nameof(L));
        public static ClothingSize XL = new(5, nameof(XL));
        public static ClothingSize XXL = new(6, nameof(XXL));

        public ClothingSize(int id, string name) : base(id, name)
        {
        }

        public static ClothingSize Parse(string size)
        {
            return size.ToUpper() switch
            {
                nameof(XS) => XS,
                nameof(S) => S,
                nameof(M) => M,
                nameof(L) => L,
                nameof(XL) => XL,
                nameof(XXL) => XXL,
                _ => throw new ArgumentException("Unknown clothing size")
            };
        }
    }
}