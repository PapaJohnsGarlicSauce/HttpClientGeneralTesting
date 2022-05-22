#nullable enable

using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using TypedConfiguringHttpClientExample.Models.Clients;

namespace NamedConfiguringHttpClientExample.Controllers
{
    [ApiController]
    [Route("api/second-typed-bored")]
    public class SecondBoredController : ControllerBase
    {
        // Typed client can be injected and consumed directly by controller!
        private readonly SecondBoredClientService _secondClientService;

        public SecondBoredController(SecondBoredClientService secondClientService)
        {
            _secondClientService = secondClientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _secondClientService.GetActivityAsync());
            }
            catch (HttpRequestException)
            {
                throw new System.Exception("Look at me weeee");
            }

        }
    }
}
