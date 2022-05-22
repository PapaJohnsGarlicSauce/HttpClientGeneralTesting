using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace NamedConfiguringHttpClientExample.Controllers
{
    [ApiController]
    [Route("api/first-named-bored")]
    public class FirstBoredController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public FirstBoredController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Create HTTPClient object using appropriate name
            var client = _clientFactory.CreateClient("FirstBoredClient");

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
