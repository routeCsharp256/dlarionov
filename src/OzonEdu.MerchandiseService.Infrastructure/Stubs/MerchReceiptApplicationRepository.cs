using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Infrastructure.Stubs
{
    public class MerchReceiptApplicationRepository : IMerchReceiptApplicationRepository
    {
        public Task<IReadOnlyList<MerchReceiptApplication>> FindByEmployeeEmailAsync(Email email, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchReceiptApplication> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<MerchReceiptApplication>> FindByIdsAsync(IReadOnlyList<int> id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<MerchReceiptApplication>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchReceiptApplication> CreateAsync(MerchReceiptApplication merchReceiptAppToCreate, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchReceiptApplication> UpdateAsync(MerchReceiptApplication merchReceiptAppToUpdate, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}