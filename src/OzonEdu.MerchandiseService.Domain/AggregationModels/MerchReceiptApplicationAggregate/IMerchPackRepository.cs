using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    /// <summary>
    /// Репозиторий для управления сущностью <see cref="MerchPack"/>
    /// </summary>
    public interface IMerchPackRepository : IRepository<MerchPack>
    {
        Task<MerchPack> FindById(int id, CancellationToken cancellationToken);

        Task<IReadOnlyCollection<MerchPack>> FindByIds(IReadOnlyCollection<int> id, CancellationToken cancellationToken);

        Task<IReadOnlyCollection<MerchPack>> GetAll(CancellationToken cancellationToken);

        Task<MerchPack> Create(MerchPack merchPackToCreate, CancellationToken cancellationToken);

        Task<MerchPack> Update(MerchPack merchPackToUpdate, CancellationToken cancellationToken);
    }
}