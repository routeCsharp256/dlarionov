using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptRequestAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Stubs
{
    public class MerchReceiptRepository : IMerchReceiptRepository
    {
        public Task<MerchReceiptRequest> CreateAsync(MerchReceiptRequest itemToCreate, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchReceiptRequest> FindByIdAsync(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchReceiptRequest> FindByRequestNumberAsync(RequestNumber requestNumber, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}