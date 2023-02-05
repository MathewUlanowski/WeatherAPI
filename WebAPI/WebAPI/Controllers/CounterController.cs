using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using WebAPI.Application.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CounterController : ControllerBase
    {
        private readonly ILogger<CounterController> _logger;
        private readonly IRedisService _redisService;

        public CounterController(ILogger<CounterController> logger, RedisService redisService)
        {
            _logger = logger;
            _redisService = redisService;
        }

        [HttpGet("GetCounter")]
        public IActionResult Get()
        {
            var result = _redisService.GetCounter();
            return Ok(result);
        }
    }
}
