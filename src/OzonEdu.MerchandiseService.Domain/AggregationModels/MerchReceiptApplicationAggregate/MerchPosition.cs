using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    public class MerchPosition : Entity
    {            
        public Merch Merch { get; }
        public Quantity Quantity { get; private set; }

        public MerchPosition(Merch merch, Quantity quantity)
        {
            Merch = merch;
            Quantity = quantity;
        }

        public void IncreaseQuantity(int valueToIncrease)
        {
            if (valueToIncrease < 0)
                throw new NegativeValueException($"{nameof(valueToIncrease)} value is negative");
            Quantity = new Quantity(this.Quantity.Value + valueToIncrease);
        }
    }
}
