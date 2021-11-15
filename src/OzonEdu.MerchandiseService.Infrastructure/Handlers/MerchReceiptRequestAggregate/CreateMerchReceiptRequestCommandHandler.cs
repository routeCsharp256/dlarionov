using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Infrastructure.Commands.CreateMerchReceiptRequest;

namespace OzonEdu.MerchandiseService.Infrastructure.Handlers.MerchReceiptRequestAggregate
{
    public class CreateMerchReceiptRequestCommandHandler : IRequestHandler<CreateMerchReceiptRequestCommand, int>
    {


        public CreateMerchReceiptRequestCommandHandler()
        {
        }

        public async Task<int> Handle(CreateMerchReceiptRequestCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}