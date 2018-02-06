using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Distributor.Domain;
using Distributor.Domain.Configuration;
using Distributor.Infrastructure.Common.HttpClient;
using Distributor.Infrastructure.Ford.Interfaces;
using Distributor.Infrastructure.Toyota.Interfaces;

namespace Distributor.Infrastructure.Toyota
{
    public class ToyotaProxy : IToyotaProxy
    {
        private readonly IHttpClient _httpClient;
        private readonly IFordMapper _fordMapper;
        public ToyotaProxy(IHttpClient httpClient, IFordMapper fordMapper)
        {
            _httpClient = httpClient;
            _fordMapper = fordMapper;
        }

        public IList<Car> GetAll(ToyotaConfiguration configuration)
        {
            var headerValue = GetHeader(configuration);
            var url = GetUrl("GET_ALL",configuration);

            var cars = _httpClient.Get(url, headerValue, "BASIC");

            return _fordMapper.MapJsonToDomain(cars);
        }

        private string GetUrl(string action, ToyotaConfiguration configuration)
        {
            var baseUrl = configuration.BaseUrl;
            var actionUrl = configuration.Actions[action];

            var url = $"{baseUrl}{actionUrl}";
            return url;
        }

        private string GetHeader(ToyotaConfiguration configuration)
        {
            var user = configuration.Credentials["USERNAME"];
            var password = configuration.Credentials["PASSWORD"];

            var byteArray = Encoding.ASCII.GetBytes($"{user}:{password}");
            var headerValue = Convert.ToBase64String(byteArray);
            return headerValue;
        }
    }
}