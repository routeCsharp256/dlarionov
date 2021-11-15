using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptRequestAggregate
{
    /// <summary>
    /// Репозиторий для управления сущностью <see cref="MerchReceiptRequest"/>
    /// </summary>
    public interface IMerchReceiptRepository : IRepository<MerchReceiptRequest>
    {
        Task<MerchReceiptRequest> CreateAsync(MerchReceiptRequest itemToCreate, CancellationToken cancellationToken);

        Task<MerchReceiptRequest> FindByIdAsync(int id, CancellationToken cancellationToken);

        Task<MerchReceiptRequest> FindByRequestNumberAsync(RequestNumber requestNumber, CancellationToken cancellationToken);
    }
}