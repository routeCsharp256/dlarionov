using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Infrastructure.Queries.MerchReceiptApplicationAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Queries.MerchReceiptApplicationAggregate.Responses;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.MerchReceiptApplicationAggregate
{
    public class GetAllEmployeeMerchPackQueryHandler : IRequestHandler<GetAllEmployeeMerchPackQuery, GetAllEmployeeMerchPackQueryResponse>
    {
        private readonly IMerchReceiptApplicationRepository _merchReceiptApplication;

        public GetAllEmployeeMerchPackQueryHandler(IMerchReceiptApplicationRepository merchReceiptApplication)
        {
            _merchReceiptApplication = merchReceiptApplication;
        }

        public async Task<GetAllEmployeeMerchPackQueryResponse> Handle(GetAllEmployeeMerchPackQuery request, CancellationToken cancellationToken)
        {
            var employeeEmail = Email.Create(request.Email);
            
            var merchReceiptApplications =
                await _merchReceiptApplication.FindByEmployeeEmail(employeeEmail, cancellationToken);

            var result = new GetAllEmployeeMerchPackQueryResponse()
            {
                MerchPacks = merchReceiptApplications
                    .Select(x => x.MerchPack)
                    .ToArray()
            };
            return result;
        }
    }
}