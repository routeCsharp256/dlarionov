using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptRequestAggregate
{
    public class RequestNumber : ValueObject
    {
        public RequestNumber(long value)
        {
            Value = value;
        }

        public long Value { get; }

        public static RequestNumber Create(long requestNumberValue)
        {
            if (requestNumberValue > 0)
            {
                return new RequestNumber(requestNumberValue);
            }

            throw new ArgumentException($"Request number value is invalid: {requestNumberValue}");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}