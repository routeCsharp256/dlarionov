using MediatR;
using OzonEdu.MerchandiseService.Infrastructure.Queries.StockItemAggregate.Responses;

namespace OzonEdu.MerchandiseService.Infrastructure.Queries.StockItemAggregate
{
    public class GetAllEmployeeMerchReceiptApplicationQuery : IRequest<GetAllEmployeeMerchReceiptApplicationQueryResponse>
    {
        public string Email { get; set; }
    }
}