using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Email Create(string emailValue)
        {
            var emailRegexPattern =
                @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            
            if (Regex.IsMatch(emailValue, emailRegexPattern))
            {
                return new Email(emailValue);
            }

            throw new ArgumentException($"Email value is invalid: {emailValue}");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}