using System;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Distributor.Infrastructure.Common.HttpClient
{
    public class HttpClient:IHttpClient
    {
        public string Get(string url,string headerValue,string schema)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization =  new AuthenticationHeaderValue(schema,headerValue);
                var respuesta = client.GetStringAsync(url);
                return respuesta.Result;
            }
        }

        public HttpResponseMessage  Post(string url, StringContent content, string schema, string headerValue)
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", headerValue);

                 return client.PostAsync(url,content).Result;
            }
        }
    }
}