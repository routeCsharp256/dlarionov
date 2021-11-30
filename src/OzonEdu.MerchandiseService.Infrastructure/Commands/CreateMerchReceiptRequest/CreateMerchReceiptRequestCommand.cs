using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.ValueObjects;

namespace OzonEdu.MerchandiseService.Infrastructure.Commands.CreateMerchReceiptRequest
{
    public class CreateMerchReceiptRequestCommand : IRequest<int>
    {
        public IReadOnlyList<Sku> Skus { get; set; }
    }
}