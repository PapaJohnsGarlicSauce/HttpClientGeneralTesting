using ConfiguringHttpClientExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConfiguringHttpClientExample.Controllers
{
    [ApiController]
    [Route("api/basic-bored")]
    public class BasicBoredController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public BasicBoredController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var uri = new Uri("http://www.boredapi.com/api/activity/");

            // Create HTTPClient object from Factory instance
            var client = _clientFactory.CreateClient();

            var response = await client.GetAsync(uri);

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
