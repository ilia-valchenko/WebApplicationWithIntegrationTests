using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApplicationWithIntegrationTests.IntegrationTests.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<TResult> GetContentAsAsync<TResult>(this HttpResponseMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (message.Content == null)
            {
                throw new ArgumentException("The content of the given HttpResponseMessage is null.");
            }

            string stringRepresentationOfContent = await message.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResult>(stringRepresentationOfContent);
        }
    }
}