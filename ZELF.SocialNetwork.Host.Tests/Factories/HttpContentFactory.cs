using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace ZELF.SocialNetwork.Host.Tests.Factories
{
    public static class HttpContentFactory
    {
        public static StringContent GetContent<T>(this T obj) => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");
    }
}
