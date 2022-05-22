using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace NamedConfiguringHttpClientExample.Controllers
{
    [ApiController]
    [Route("api/second-named-bored")]
    public class SecondBoredController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public SecondBoredController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Create HTTPClient object using appropriate name
            var client = _clientFactory.CreateClient("SecondBoredClient");

            var response = await client.GetAsync("activity");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync();
                return Ok(content);
            }
            else
            {
                return StatusCode(500, "Internal error occurred.");
            }

        }
    }
}
