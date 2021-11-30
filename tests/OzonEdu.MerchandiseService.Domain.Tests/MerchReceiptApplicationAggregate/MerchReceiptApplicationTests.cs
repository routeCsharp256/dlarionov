using System;
using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Exceptions.MerchReceiptApplicationAggregate;
using Xunit;

namespace OzonEdu.MerchandiseService.Domain.Tests.MerchReceiptApplicationAggregate
{
    public class MerchReceiptApplicationTests
    {
        public static IEnumerable<object[]> GetDeclineCorrectStatuses()
        {
            yield return new object[] { ApplicationStatus.InQueue };
            yield return new object[] { ApplicationStatus.Created };
            yield return new object[] { ApplicationStatus.ReceiveWaiting };
        }

        public static IEnumerable<object[]> GetDeclineIncorrectStatuses()
        {
            yield return new object[] { ApplicationStatus.Cancelled };
            yield return new object[] { ApplicationStatus.Reserved };
        }

        public static IEnumerable<object[]> GiveOutSuccessData()
        {
            yield return new object[] { false, DateTimeOffset.UtcNow, ApplicationStatus.InQueue };
            yield return new object[] { true, DateTimeOffset.UtcNow, ApplicationStatus.InQueue };
            yield return new object[] { false, DateTimeOffset.UtcNow, ApplicationStatus.Created };
            yield return new object[] { true, DateTimeOffset.UtcNow, ApplicationStatus.Created };
        }

        public static IEnumerable<object[]> GiveOutFailureData()
        {
            yield return new object[] { false, DateTimeOffset.UtcNow, ApplicationStatus.ReceiveWaiting };
            yield return new object[] { true, DateTimeOffset.UtcNow, ApplicationStatus.Cancelled };
            yield return new object[] { false, DateTimeOffset.UtcNow, ApplicationStatus.Cancelled };
            yield return new object[] { true, DateTimeOffset.UtcNow, ApplicationStatus.Reserved };
        }

        [Theory]
        [MemberData(nameof(GetDeclineCorrectStatuses))]
        public void DeclineSuccess(ApplicationStatus applicationStatus)
        {
            //Arrange
            var receiptNumber = ReceiptNumber.Create(123);
            var employee = Employee.Create(Email.Create("www@domain.com"), ClothingSize.L, "Vadim Garaev");
            var merchPack = new MerchPack("NewOne", new List<Merch>());

            var createAtDate = Date.Create(DateTimeOffset.UtcNow);
            var giveOutDate = Date.Create(DateTimeOffset.Now);

            var newMerchReceiptApplication = new MerchReceiptApplication(receiptNumber, employee, merchPack,
                applicationStatus, createAtDate, giveOutDate);

            //Act
            newMerchReceiptApplication.Decline();

            //Assert
            Assert.Equal(ApplicationStatus.Cancelled, newMerchReceiptApplication.ApplicationStatus);
        }

        [Theory]
        [MemberData(nameof(GetDeclineIncorrectStatuses))]
        public void DeclineFailure(ApplicationStatus applicationStatus)
        {
            //Arrange
            var receiptNumber = ReceiptNumber.Create(123);
            var employee = Employee.Create(Email.Create("www@domain.com"), ClothingSize.L, "Vadim Garaev");
            var merchPack = new MerchPack("NewOne", new List<Merch>());

            var createAtDate = Date.Create(DateTimeOffset.UtcNow);
            var giveOutDate = Date.Create(DateTimeOffset.Now);

            var newMerchReceiptApplication = new MerchReceiptApplication(receiptNumber, employee, merchPack,
                applicationStatus, createAtDate, giveOutDate);

            //Act

            //Assert
            Assert.Throws<MerchReceiptApplicationDeclineException>(() => newMerchReceiptApplication.Decline());
        }

        [Theory]
        [MemberData(nameof(GiveOutSuccessData))]
        public void GiveOutSuccess(bool isAvailableToGiveOut, DateTimeOffset giveOutAt, ApplicationStatus applicationStatus)
        {
            //Arrange
            var receiptNumber = ReceiptNumber.Create(123);
            var employee = Employee.Create(Email.Create("www@domain.com"), ClothingSize.L, "Vadim Garaev");
            var merchPack = new MerchPack("NewOne", new List<Merch>());

            var createAtDate = Date.Create(DateTimeOffset.UtcNow);
            var giveOutDate = Date.Create(giveOutAt);

            var newMerchReceiptApplication = new MerchReceiptApplication(receiptNumber, employee, merchPack,
                applicationStatus, createAtDate, null);

            //Act
            newMerchReceiptApplication.GiveOut(isAvailableToGiveOut, giveOutDate);

            //Assert
            Assert.NotEqual(ApplicationStatus.Created, newMerchReceiptApplication.ApplicationStatus);
        }

        [Theory]
        [MemberData(nameof(GiveOutFailureData))]
        public void GiveOutFailure(bool isAvailableToGiveOut, DateTimeOffset giveOutAt, ApplicationStatus applicationStatus)
        {
            //Arrange
            var receiptNumber = ReceiptNumber.Create(123);
            var employee = Employee.Create(Email.Create("www@domain.com"), ClothingSize.L, "Vadim Garaev");
            var merchPack = new MerchPack("NewOne", new List<Merch>());

            var createAtDate = Date.Create(DateTimeOffset.UtcNow);
            var giveOutDate = Date.Create(giveOutAt);

            var newMerchReceiptApplication = new MerchReceiptApplication(receiptNumber, employee, merchPack,
                applicationStatus, createAtDate, null);

            //Act

            //Assert
            Assert.Throws<MerchReceiptApplicationGiveOutException>(() =>
                newMerchReceiptApplication.GiveOut(isAvailableToGiveOut, giveOutDate));
        }

        [Fact]
        public void SetGiveOutAtSuccess()
        {
            //Arrange
            var employee = Employee.Create(Email.Create("www@domain.com"), ClothingSize.L, "Vadim Garaev");
            var merchPack = new MerchPack("NewOne", new List<Merch>());

            var createAtDate = Date.Create(DateTimeOffset.UtcNow);
            var giveOutDate = Date.Create(DateTimeOffset.Now);

            var newMerchReceiptApplication = MerchReceiptApplication.Create(employee, merchPack, createAtDate,
                new List<MerchReceiptApplication>());

            //Act
            newMerchReceiptApplication.SetGiveOutAt(giveOutDate);

            //Assert
            Assert.Equal(giveOutDate.Value.Date, newMerchReceiptApplication.CreatedAt.Value.Date);
        }

        [Fact]
        public void CreateIncorrectFailure()
        {
            //Arrange
            var employee = Employee.Create(Email.Create("www@domain.com"), ClothingSize.L, "Vadim Garaev");
            var merchPack = new MerchPack("NewOne", new List<Merch>());

            var createAtDate = Date.Create(DateTimeOffset.UtcNow);
            var giveOutDate = Date.Create(DateTimeOffset.Now.Add(-TimeSpan.FromDays(1)));

            var newMerchReceiptApplication = MerchReceiptApplication.Create(employee, merchPack, createAtDate,
                new List<MerchReceiptApplication>());

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => newMerchReceiptApplication.SetGiveOutAt(giveOutDate));
        }
    }
}
