using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Services;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public partial class DavinciController : ControllerBase
    {
        private readonly IDavinciService _davinciService;
        public DavinciController(DavinciService davinciService) 
        {
            _davinciService= davinciService;
        }
    }
}
