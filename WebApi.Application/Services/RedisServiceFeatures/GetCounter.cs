using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Application.Services
{
    public partial class RedisService
    {
        public string GetCounter() {
            string result = null;

            try
            {
                string key = "Counter";

                var counterFromRedis = _redisCache.GetString(key);
                if(int.TryParse(counterFromRedis, out int counter))
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }
                result = counter.ToString();
                _redisCache.SetString(key, result);

            }
            catch (RedisConnectionException)
            {
                result = "There was an error connecting to Redis";
            }

            return result;
        }
    }
}
