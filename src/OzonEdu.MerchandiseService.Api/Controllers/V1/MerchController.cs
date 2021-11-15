using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Domain.AggregationModels.MerchReceiptApplicationAggregate;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Infrastructure.Commands.CreateMerchReceiptApplication;
using OzonEdu.MerchandiseService.Infrastructure.Queries.MerchReceiptApplicationAggregate;

namespace OzonEdu.MerchandiseService.Api.Controllers.V1
{
    [ApiController]
    [Route("v1/api/merch")]
    [Produces("application/json")]
    public class MerchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MerchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("info/employee/{email:string}")]
        public async Task<ActionResult<IReadOnlyList<MerchPack>>> GetInfoByEmployeeEmail(string email, CancellationToken token)
        {
            var result = await _mediator.Send(new GetAllEmployeeMerchPackQuery()
            {
                Email = email
            }, token);

            return Ok(result);
        }

        [HttpPost("issuance")]
        public async Task<ActionResult> AddIssuance(MerchIssuanceViewModel merchIssuanceViewModel, CancellationToken token)
        {
            var createStockItemCommand = new CreateMerchReceiptApplicationCommand
            {
                EmployeeName = merchIssuanceViewModel.EmployeeName,
                EmployeeEmail = merchIssuanceViewModel.EmployeeEmail,
                MerchPack = merchIssuanceViewModel.MerchPack,
                ClothingSize = merchIssuanceViewModel.ClothingSize
            };
            var result = await _mediator.Send(createStockItemCommand, token);
            return Ok(result);
        }
    }
}
