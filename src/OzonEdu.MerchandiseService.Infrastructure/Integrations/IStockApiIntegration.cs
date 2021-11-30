using System.Collections.Generic;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Infrastructure.Integrations
{
    public interface IStockApiIntegration
    {
        Task<bool> IsItemAvailable(Sku sku);
        Task<bool> IsItemCollectionAvailable(IReadOnlyCollection<Sku> sku);
        Task EmployeeMerchandiseRequest(IReadOnlyCollection<Sku> sku, Email employeeEmail);
    }
}
