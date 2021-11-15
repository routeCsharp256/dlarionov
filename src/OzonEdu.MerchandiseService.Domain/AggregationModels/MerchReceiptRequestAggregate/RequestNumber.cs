namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptRequestAggregate
{
    public class RequestNumber
    {
        public RequestNumber(long value)
        {
            Value = value;
        }

        public long Value { get; }
    }
}