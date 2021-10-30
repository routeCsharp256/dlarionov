using System;
using System.Threading.Tasks;
using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;

namespace OzonEdu.MerchandiseService.Api.GrpcServices
{
    public class MerchandiseGrpcService : MerchGrpc.MerchGrpcBase
    {
        public MerchandiseGrpcService()
        {
        }

        public override async Task<GetMerchInfoResponse> GetMerchIssuanceInfo(GetMerchInfoRequest request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }

        public override async Task<Empty> RequestMerch(MerchIssuanceRequest request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }
    }
}