using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions.MerchReceiptApplicationAggregate
{
    public class MerchReceiptApplicationDeclineException : Exception
    {
        public MerchReceiptApplicationDeclineException(string message) : base(message)
        {

        }

        public MerchReceiptApplicationDeclineException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
