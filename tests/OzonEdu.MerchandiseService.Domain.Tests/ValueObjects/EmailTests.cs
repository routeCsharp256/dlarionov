using System;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.ValueObjects
{
    public class EmailTests
    {
        [Theory]
        [InlineData("www@domain.com")]
        [InlineData("123someone@dd.ase")]
        [InlineData("nope@data.data.data")]
        public void CreateCorrectEmailSuccess(string emailValue)
        {
            //Arrange
            var expectedValue = emailValue;

            //Act
            var email = Email.Create(emailValue);

            //Assert
            Assert.Equal(expectedValue, email.Value);
        }

        [Theory]
        [InlineData("wwwcom")]
        [InlineData("123someone.com")]
        [InlineData("@data.data.data")]
        [InlineData("@data.data.d.d")]
        [InlineData("")]
        public void CreateIncorrectEmailFailure(string emailValue)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => Email.Create(emailValue));
        }
    }
}
