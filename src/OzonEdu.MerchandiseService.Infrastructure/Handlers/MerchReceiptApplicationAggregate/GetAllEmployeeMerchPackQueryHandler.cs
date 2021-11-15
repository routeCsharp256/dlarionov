using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Infrastructure.Queries.MerchReceiptApplicationAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Queries.MerchReceiptApplicationAggregate.Responses;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.MerchReceiptApplicationAggregate
{
    public class GetAllEmployeeMerchPackQueryHandler : IRequestHandler<GetAllEmployeeMerchPackQuery, GetAllEmployeeMerchPackQueryResponse>
    {
        public GetAllEmployeeMerchPackQueryHandler()
        {
        }
        
        public async Task<GetAllEmployeeMerchPackQueryResponse> Handle(GetAllEmployeeMerchPackQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}