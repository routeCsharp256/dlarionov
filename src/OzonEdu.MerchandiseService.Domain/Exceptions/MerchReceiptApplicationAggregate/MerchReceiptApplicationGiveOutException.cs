using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions.MerchReceiptApplicationAggregate
{
    public class MerchReceiptApplicationGiveOutException : Exception
    {
        public MerchReceiptApplicationGiveOutException(string message) : base(message)
        {

        }

        public MerchReceiptApplicationGiveOutException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
