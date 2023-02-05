using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    public partial class DavinciController
    {
        // POST api/<ValuesController1>
        [HttpPost("GenerateDavinciResponse")]
        public async Task<IActionResult> Post([FromBody] GenerateGPTMessageRequest request)
        {
            var response = await _davinciService.GenerateGPTMessage(request);


            return Ok(response);
        }

    }
}
