using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects
{
    public class Date : ValueObject
    {
        public Date(DateTimeOffset value)
        {
            Value = value;
        }

        public DateTimeOffset Value { get; }

        public static Date Create(DateTimeOffset dateValue)
        {
            if (dateValue.Date > new DateTimeOffset(new DateTime(1900,1,1)).Date)
            {
                return new Date(dateValue);
            }

            throw new ArgumentException($"Date value is invalid: {dateValue}");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}