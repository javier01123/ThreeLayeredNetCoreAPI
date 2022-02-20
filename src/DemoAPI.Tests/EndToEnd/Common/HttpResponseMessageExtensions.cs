using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoAPI.Tests.EndToEnd.Common
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<T> Deserialize<T>(this HttpResponseMessage res)where T : class
        {
            var json = await res.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
