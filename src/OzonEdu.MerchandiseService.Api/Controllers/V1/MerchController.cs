using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.Api.Models;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.Api.Controllers.V1
{
    [ApiController]
    [Route("v1/api/merch")]
    [Produces("application/json")]
    public class MerchController : ControllerBase
    {
        public MerchController()
        {
        }

        [HttpGet("info/{id:int}")]
        public async Task<ActionResult<MerchInfo>> GetInfoById(int id, CancellationToken token)
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
