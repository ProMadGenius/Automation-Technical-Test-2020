using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace APITests.Core
{
    public class Base
    {
        public static HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://reqres.in/api/"),

            DefaultRequestHeaders = { Accept = { new MediaTypeWithQualityHeaderValue("application/json") } }
        };

        public Base()
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
