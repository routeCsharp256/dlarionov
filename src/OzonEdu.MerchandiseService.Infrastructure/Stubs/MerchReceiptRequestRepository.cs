using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptRequestAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Stubs
{
    public class MerchReceiptRequestRepository : IMerchReceiptRequestRepository
    {
        public async Task<MerchReceiptRequest> Create(MerchReceiptRequest itemToCreate, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<MerchReceiptRequest> FindById(int id, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<MerchReceiptRequest> FindByRequestNumber(RequestNumber requestNumber, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}