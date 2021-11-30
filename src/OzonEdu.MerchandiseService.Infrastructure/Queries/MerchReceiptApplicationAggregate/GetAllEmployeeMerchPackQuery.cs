using MediatR;
using OzonEdu.MerchandiseService.Infrastructure.Queries.MerchReceiptApplicationAggregate.Responses;

namespace OzonEdu.MerchandiseService.Infrastructure.Queries.MerchReceiptApplicationAggregate
{
    public class GetAllEmployeeMerchPackQuery : IRequest<GetAllEmployeeMerchPackQueryResponse>
    {
        public string Email { get; set; }
    }
}