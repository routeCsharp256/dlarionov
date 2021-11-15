using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Infrastructure.Commands.CreateMerchReceiptApplication;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.MerchReceiptApplicationAggregate
{
    public class CreateMerchReceiptApplicationCommandHandler : IRequestHandler<CreateMerchReceiptApplicationCommand, int>
    {
        public CreateMerchReceiptApplicationCommandHandler()
        {
        }
        
        public async Task<int> Handle(CreateMerchReceiptApplicationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}