using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    /// <summary>
    /// Номер заявки
    /// </summary>
    public class ReceiptNumber : ValueObject
    {
        public ReceiptNumber(long value)
        {
            Value = value;
        }

        public long Value { get; }

        public static ReceiptNumber Create(long receiptNumberValue)
        {
            if (receiptNumberValue > 0)
            {
                return new ReceiptNumber(receiptNumberValue);
            }

            throw new ArgumentException($"Request number value is invalid: {receiptNumberValue}");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}