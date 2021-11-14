using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchandiseService.Api.Models;
using OzonEdu.MerchandiseService.HttpModels;

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

        [HttpGet("info/employee/{employeeId:int}")]
        public async Task<ActionResult<MerchInfo>> GetInfoByEmployeeId(int employeeId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        [HttpPost("issuance")]
        public async Task<ActionResult> AddIssuance(MerchIssuanceViewModel merchIssuanceViewModel, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
