using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Infrastructure.Stubs
{
    public class MerchReceiptApplicationRepository : IMerchReceiptApplicationRepository
    {
        private MerchReceiptApplication _merchReceiptApplication =
            MerchReceiptApplication.Create(Employee.Create(Email.Create("www@mail.ru"), ClothingSize.L, "Vadim Garaev"),
                new MerchPack("Pen", new List<Merch> { new Merch(Sku.Create(1), "pen", MerchType.Stationery) }),
                Date.Create(DateTimeOffset.Now),
                new List<MerchReceiptApplication>());
        
        public async Task<IReadOnlyCollection<MerchReceiptApplication>> FindByEmployeeEmail(Email email, CancellationToken cancellationToken)
        {
            return new List<MerchReceiptApplication>() { _merchReceiptApplication };
        }

        public async Task<MerchReceiptApplication> FindById(int id, CancellationToken cancellationToken)
        {
            return _merchReceiptApplication;
        }

        public async Task<IReadOnlyCollection<MerchReceiptApplication>> FindByIds(IReadOnlyList<int> id, CancellationToken cancellationToken)
        {
            return new List<MerchReceiptApplication>() { _merchReceiptApplication };
        }

        public async Task<IReadOnlyCollection<MerchReceiptApplication>> GetAll(CancellationToken cancellationToken)
        {
            return new List<MerchReceiptApplication>() { _merchReceiptApplication };
        }

        public async Task<MerchReceiptApplication> Create(MerchReceiptApplication merchReceiptAppToCreate, CancellationToken cancellationToken)
        {
            return merchReceiptAppToCreate;
        }

        public async Task<MerchReceiptApplication> Update(MerchReceiptApplication merchReceiptAppToUpdate, CancellationToken cancellationToken)
        {
            return merchReceiptAppToUpdate;
        }
    }
}