using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchandiseService.HttpModels;

namespace OzonEdu.MerchandiseService.HttpClients
{
    public interface IMerchandiseHttpClient
    {
        Task<MerchInfoResponse> GetMerchInfoById(int id, CancellationToken token);
        Task RequestMerhIssuance(MerchIssuanceViewModel merchIssuanceViewModel, CancellationToken token);
    }

    public class MerchandiseHttpClient : IMerchandiseHttpClient
    {
        private readonly HttpClient _httpClient;

        public MerchandiseHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MerchInfoResponse> GetMerchInfoById(int id, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"v1/api/merch/info/{id}", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchInfoResponse>(body);
        }

        public async Task RequestMerhIssuance(MerchIssuanceViewModel merchIssuanceViewModel, CancellationToken token)
        {
            StringContent content = SerializeToString(merchIssuanceViewModel);
            await _httpClient.PostAsync("v1/api/merch/issuance/", content, token);
        }

        private StringContent SerializeToString(object data)
        {
            string serializedObject = JsonSerializer.Serialize(data);

            var content = data != null ?
                new StringContent(serializedObject) :
                new StringContent(string.Empty);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return content;
        }
    }
}