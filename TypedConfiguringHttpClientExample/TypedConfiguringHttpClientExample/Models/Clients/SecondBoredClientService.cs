#nullable enable

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TypedConfiguringHttpClientExample.Models.Clients
{
    public sealed class SecondBoredClientService
    {
        private readonly HttpClient _httpClient;

        public SecondBoredClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // Configuration can also be specified during registration via lambda
            // I personally like putting them here so it doesn't make Startup() into a bloated mess
            _httpClient.BaseAddress = new Uri("https://www.boredapi.com/api/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/xml");
        }

        public async Task<string?> GetActivityAsync()
        {
            var response = await _httpClient.GetAsync("activity");
            return response.IsSuccessStatusCode
                ? await response.Content.ReadAsStringAsync()
                : null;
        }
    }
}
