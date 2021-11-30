using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    /// <summary>
    /// Репозиторий для управления сущностью <see cref="MerchReceiptApplication"/>
    /// </summary>
    public interface IMerchReceiptApplicationRepository : IRepository<MerchReceiptApplication>
    {
        Task<IReadOnlyCollection<MerchReceiptApplication>> FindByEmployeeEmail(Email email, CancellationToken cancellationToken);

        Task<MerchReceiptApplication> FindById(int id, CancellationToken cancellationToken);

        Task<IReadOnlyCollection<MerchReceiptApplication>> FindByIds(IReadOnlyList<int> id, CancellationToken cancellationToken);

        Task<IReadOnlyCollection<MerchReceiptApplication>> GetAll(CancellationToken cancellationToken);

        Task<MerchReceiptApplication> Create(MerchReceiptApplication merchReceiptAppToCreate, CancellationToken cancellationToken);

        Task<MerchReceiptApplication> Update(MerchReceiptApplication merchReceiptAppToUpdate, CancellationToken cancellationToken);
    }
}