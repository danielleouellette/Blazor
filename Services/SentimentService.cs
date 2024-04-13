 

namespace FinalBlazor_ServerApp.Services
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using FinalBlazor_ServerApp.Model;

    public class SentimentService
    {
        
        private readonly HttpClient _httpClient;

        public SentimentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    /*
        public async Task<SentimentResponse> PredictSentimentAsync(SentimentRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:5123/predict", request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<SentimentResponse>();
        }
    */
        public async Task<ModelOutput> PredictSentimentAsync(ModelInput request)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync("https://localhost:5123/predict", request);

            if (httpResponse.IsSuccessStatusCode)
            {
                return await httpResponse.Content.ReadFromJsonAsync<ModelOutput>();
            }
            else
            {
                // Handle error response (e.g., log the error, throw an exception, etc.)
                throw new Exception("API call failed.");
            }
        }

    }
}


