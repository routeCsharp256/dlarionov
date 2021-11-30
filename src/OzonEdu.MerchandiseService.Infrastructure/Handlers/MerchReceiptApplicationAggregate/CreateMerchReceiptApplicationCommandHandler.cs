using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;
using OzonEdu.MerchandiseService.Infrastructure.Commands.CreateMerchReceiptApplication;
using OzonEdu.MerchandiseService.Infrastructure.Integrations;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.MerchReceiptApplicationAggregate
{
    public class CreateMerchReceiptApplicationCommandHandler : IRequestHandler<CreateMerchReceiptApplicationCommand, long>
    {
        private readonly IMerchReceiptApplicationRepository _merchReceiptApplication;
        private readonly IMerchPackRepository _merchPackRepository;
        private readonly IStockApiIntegration _stockApiIntegration;

        public CreateMerchReceiptApplicationCommandHandler(IMerchReceiptApplicationRepository merchReceiptApplication,
            IMerchPackRepository merchPackRepository,
            IStockApiIntegration stockApiIntegration)
        {
            _merchReceiptApplication = merchReceiptApplication;
            _merchPackRepository = merchPackRepository;
            _stockApiIntegration = stockApiIntegration;
        }

        public async Task<long> Handle(CreateMerchReceiptApplicationCommand request, CancellationToken cancellationToken)
        {
            var merchPack = await _merchPackRepository.FindById(request.MerchPack, cancellationToken);
            var employeeRequests =
                 await _merchReceiptApplication.FindByEmployeeEmail(Email.Create(request.EmployeeEmail), cancellationToken);

            var newMerchReceiptApp = MerchReceiptApplication.Create(
                employee: new Employee(Email.Create(request.EmployeeEmail), ClothingSize.Parse(request.ClothingSize),
                    request.EmployeeName),
                merchPack: merchPack,
                createdAt: Date.Create(DateTimeOffset.UtcNow),
                alreadyExistedRequests: employeeRequests);

            newMerchReceiptApp = await _merchReceiptApplication.Create(newMerchReceiptApp, cancellationToken);

            var isMerchPackAvailable =
                await _stockApiIntegration.IsItemCollectionAvailable(newMerchReceiptApp.MerchPack.MerchCollection
                    .Select(x => x.Sku).ToArray());

            newMerchReceiptApp.GiveOut(isMerchPackAvailable, Date.Create(DateTimeOffset.UtcNow));

            await _merchReceiptApplication.Update(newMerchReceiptApp, cancellationToken);

            return newMerchReceiptApp.ReceiptNumber.Value;
        }
    }
}