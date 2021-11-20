using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions.MerchReceiptApplicationAggregate
{
    public class MerchReceiptApplicationCheckAbilityException : Exception
    {
        public MerchReceiptApplicationCheckAbilityException(string message) : base(message)
        {

        }

        public MerchReceiptApplicationCheckAbilityException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
