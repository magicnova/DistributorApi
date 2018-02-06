﻿using System.Net.Http;

namespace Distributor.Infrastructure.Common.HttpClient
{
    public interface IHttpClient
    {
        string Get(string url, string headerValue, string schema);
        HttpResponseMessage Post(string url, StringContent content, string schema, string headerValue);
    }
}