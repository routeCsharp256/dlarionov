using System.Collections.Generic;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate;

namespace OzonEdu.MerchandiseService.Infrastructure.Queries.MerchReceiptApplicationAggregate.Responses
{
    public class GetAllEmployeeMerchPackQueryResponse
    {
        public IReadOnlyList<MerchPack> MerchPacks { get; set; }
    }
}