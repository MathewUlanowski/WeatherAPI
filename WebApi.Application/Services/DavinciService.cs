using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.GPT3;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.Managers;

namespace WebAPI.Application.Services
{
    public interface IDavinciService
    {
        public Task<GenerateGPTMessageResponse> GenerateGPTMessage(GenerateGPTMessageRequest request);
    }
    public partial class DavinciService : IDavinciService
    {
        private readonly IOpenAIService _openAIService;

        public DavinciService(IConfiguration config) 
        {
            _openAIService = new OpenAIService(new OpenAiOptions
            {
                ApiKey = config["OpenAIServiceOptions:ApiKey"]
            });
        }
    }
}