using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects
{
    public class Sku : ValueObject
    {
        private Sku(long sku)
        {
            Value = sku;
        }

        public long Value { get; }

        public static Sku Create(long skuValue)
        {
            if (skuValue > 0)
            {
                return new Sku(skuValue);
            }                           

            throw new ArgumentException($"SKU value is invalid: {skuValue}");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}