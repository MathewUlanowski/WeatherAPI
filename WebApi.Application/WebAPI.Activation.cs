using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.GPT3.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Application.Services;

namespace WebAPI.Application.ActivationExtensions
{
    public static class ActivateServiceLayerExtensions
    {
        public static void AddWebApiApplicationLayer(this IServiceCollection services, string OpenAIAPIKey, Action<RedisCacheOptions> redisOptions = null)
        {
            // establishing the connection to the redis server
            if(redisOptions != null)
            {
                services.AddStackExchangeRedisCache(redisOptions);
            }
            else
            {
                // default settings for redis
                services.AddStackExchangeRedisCache(opt =>
                {
                    opt.Configuration = "redis:6379";
                    opt.InstanceName = "SampleInstance";
                });
            }
            // DI open AI api
            services.AddOpenAIService();
            // davinci service for interfacing with OpenAI's Davinci text API's for the purposes of this app
            services.AddTransient<DavinciService>();
            // redis service for communicating to the redis server
            services.AddScoped<RedisService>();
        }
    }
}
