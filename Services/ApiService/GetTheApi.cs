using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services.ApiService
{
    public class GetTheApi
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://randomuser.me/api/";

        public GetTheApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result> FetchApiData()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(ApiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ApiResponse>(responseBody);

                if (data?.Results == null || data.Results.Count == 0)
                {
                    throw new Exception("No results returned from the API.");
                }

                return data.Results[0];
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
                throw;
            }
        }
    }
}
