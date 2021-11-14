using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Domain.Contracts;

namespace OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate
{
    public interface IMerchReceiptApplicationRepository : IRepository<MerchReceiptApplication>
    {
        Task<MerchReceiptApplication> FindByEmployeeEmailAsync(Email email, CancellationToken cancellationToken);

        Task<MerchReceiptApplication> FindByIdAsync(int id, CancellationToken cancellationToken);

        Task<IReadOnlyList<MerchReceiptApplication>> FindByIdsAsync(IReadOnlyList<int> id, CancellationToken cancellationToken);

        Task<IReadOnlyList<MerchReceiptApplication>> GetAllAsync(CancellationToken cancellationToken);

        Task<MerchReceiptApplication> CreateAsync(MerchReceiptApplication merchReceiptAppToCreate, CancellationToken cancellationToken);

        Task<MerchReceiptApplication> UpdateAsync(MerchReceiptApplication merchReceiptAppToUpdate, CancellationToken cancellationToken);
    }
}