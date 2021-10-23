using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlazorYoutubeDl.Utils
{
    public static class HttpUtils
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static StringContent ToStringContent(this object obj)
        {
            var content = new StringContent(obj.ToJson(), Encoding.UTF8, "application/json");
            return content;
        }

        public static async Task<E> Parse<E>(this Task<HttpResponseMessage> message)
        {
            return await (await message).Content.Parse<E>();
        }

        public static async Task<E> Parse<E>(this HttpResponseMessage message)
        {
            return await message.Content.Parse<E>();
        }

        public static async Task<E> Parse<E>(this HttpContent content)
        {

            var json = await content.ReadAsStringAsync();
            return json.ToObject<E>();
        }

        public static E ToObject<E>(this string json)
        {
            try
            {
                var t = JsonConvert.DeserializeObject<IDictionary<string, object>>(json);
                var test = JsonConvert.DeserializeObject<E>(json);
                return test;
            }
            catch (Exception ex)
            {
                _ = ex;
                throw;
            }
            
        }

        public static E Copy<E>(this E e)
        {
            return e.ToJson().ToObject<E>();
        }

        public static int GetUserID(this ClaimsPrincipal user) => user.Identity.Name.ToInt();

    }
}
