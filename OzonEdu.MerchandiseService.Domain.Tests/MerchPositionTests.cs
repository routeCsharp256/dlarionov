using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Exceptions;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests
{
    public class MerchPositionTests
    {
        [Fact]
        public void IncreaseMerchPositionQuantity()
        {
            //Arrange 
            var merchPosition = new MerchPosition(
                new Merch(new Sku(10), "Banana", MerchType.Сlothing),
                new Quantity(10));

            var valueToIncrease = 10;

            //Act
            merchPosition.IncreaseQuantity(valueToIncrease);

            //Assert
            Assert.Equal(20, merchPosition.Quantity.Value);
        }

        [Fact]
        public void IncreaseQuantityNegativeValueSuccess()
        {
            //Arrange 
            var merchPosition = new MerchPosition(
                new Merch(new Sku(10), "Banana", MerchType.Сlothing),
                new Quantity(10));

            var valueToIncrease = -15;

            //Act

            //Assert
            Assert.Throws<NegativeValueException>(() => merchPosition.IncreaseQuantity(valueToIncrease));
        }

        [Fact]
        public void IncreaseQuantityZeroValue()
        {
            //Arrange 
            var merchPosition = new MerchPosition(
                new Merch(new Sku(10), "Banana", MerchType.Сlothing),
                new Quantity(10));

            var valueToIncrease = 0;

            //Act
            merchPosition.IncreaseQuantity(valueToIncrease);

            //Assert
            Assert.Equal(10, merchPosition.Quantity.Value);
        }
    }
}