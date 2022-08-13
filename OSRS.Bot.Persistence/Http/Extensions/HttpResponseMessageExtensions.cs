using Newtonsoft.Json;

namespace OSRS.Bot.Persistence.Http.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T?> ReadAsAsync<T>(this HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        public static async Task<string> HandleFailureAsync(this HttpResponseMessage response)
        {
            throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }
}
