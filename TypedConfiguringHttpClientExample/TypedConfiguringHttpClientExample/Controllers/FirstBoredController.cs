#nullable enable

using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using TypedConfiguringHttpClientExample.Models.Clients;

namespace NamedConfiguringHttpClientExample.Controllers
{
    [ApiController]
    [Route("api/first-typed-bored")]
    public class FirstBoredController : ControllerBase
    {
        // Typed client can be injected and consumed directly by controller!
        private readonly FirstBoredClientService _firstClientService;

        public FirstBoredController(FirstBoredClientService firstClientService)
        {
            _firstClientService = firstClientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _firstClientService.GetActivityAsync());
            }
            catch (HttpRequestException)
            {
                throw new System.Exception("Look at me weeee");
            }

        }
    }
}
