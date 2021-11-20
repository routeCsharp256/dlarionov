using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects
{
    public class Quantity : ValueObject
    {
        private Quantity(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public static Quantity Create(int quantityValue)
        {
            if (quantityValue > 0)
            {
                return new Quantity(quantityValue);
            }

            throw new ArgumentException($"SKU value is invalid: {quantityValue}");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}