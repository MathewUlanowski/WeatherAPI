using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;

namespace WebAPI.Application.Services
{
    public class GenerateGPTMessageRequest
    {
        public string message { get; set; }
    }
    public class GenerateGPTMessageResponse
    {
        public string message { get; set; }
    }
    public partial class DavinciService
    {
        public async Task<GenerateGPTMessageResponse> GenerateGPTMessage(GenerateGPTMessageRequest request)
        {
            GenerateGPTMessageResponse result = null;
            try
            {
                var completionResult = await _openAIService.Completions.CreateCompletion(new CompletionCreateRequest
                {
                    Prompt = request.message,
                    Model = Models.TextDavinciV3,
                    MaxTokens = 1000,
                    Temperature = 0.6f,
                });
                if(completionResult.Successful) 
                {
                    result = new GenerateGPTMessageResponse
                    {
                        message = completionResult.Choices[0].Text
                    };
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return result;
        }
    }
}
