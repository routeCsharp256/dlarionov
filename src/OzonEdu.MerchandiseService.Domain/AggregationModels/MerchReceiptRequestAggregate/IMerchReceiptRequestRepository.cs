using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptRequestAggregate
{
    /// <summary>
    /// Репозиторий для управления сущностью <see cref="MerchReceiptRequest"/>
    /// </summary>
    public interface IMerchReceiptRequestRepository : IRepository<MerchReceiptRequest>
    {
        Task<MerchReceiptRequest> Create(MerchReceiptRequest itemToCreate, CancellationToken cancellationToken);

        Task<MerchReceiptRequest> FindById(int id, CancellationToken cancellationToken);

        Task<MerchReceiptRequest> FindByRequestNumber(RequestNumber requestNumber, CancellationToken cancellationToken);
    }
}