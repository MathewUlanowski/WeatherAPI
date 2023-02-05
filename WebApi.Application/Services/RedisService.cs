using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.Services
{
    public interface IRedisService
    {
        public string GetCounter();
    }
    public partial class RedisService : IRedisService
    {
        #region Constructor
        private readonly IDistributedCache _redisCache;
        public RedisService(IDistributedCache redisCache) {
            _redisCache = redisCache;
        }
        #endregion

        #region Shared Functions

        #endregion
    }
}
