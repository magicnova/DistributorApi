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
        private readonly IToyotaMapper _toyotaMapper;
    public ToyotaProxy(IHttpClient httpClient, IToyotaMapper toyotaMapper)
    {
        _httpClient = httpClient;
        _toyotaMapper = toyotaMapper;
    }

        public IList<Car> GetAll(ToyotaConfiguration configuration)
        {
            var headerValue = GetHeader(configuration);
            var url = GetUrl("GET_ALL",configuration);

            var cars = _httpClient.Get(url, headerValue, "BASIC");

            return _toyotaMapper.MapCarsToDomain(cars);
        }

        public IList<Car> GetByModel(ToyotaConfiguration configuration, string model)
        {
            var headerValue = GetHeader(configuration);
            var url = $"{GetUrl("GET_BY_MODEL",configuration)}{model}";

            var cars = _httpClient.Get(url, headerValue, "BASIC");

            return _toyotaMapper.MapCarsToDomain(cars);
        }

        public IList<Car> GetByTransmission(ToyotaConfiguration configuration, string transmission)
        {
            var headerValue = GetHeader(configuration);
            var url = $"{GetUrl("GET_BY_TRANSMISSION", configuration)}{transmission}";
            
            var cars = _httpClient.Get(url, headerValue, "BASIC");

            return _toyotaMapper.MapCarsToDomain(cars);
        }

        public IList<Car> GetByEngine(ToyotaConfiguration configuration, string engine)
        {
            var headerValue = GetHeader(configuration);
            var url = $"{GetUrl("GET_BY_ENGINE",configuration)}{engine}";

            var cars = _httpClient.Get(url, headerValue, "BASIC");

            return _toyotaMapper.MapCarsToDomain(cars);     
        }

        public IList<Car> GetByYear(ToyotaConfiguration configuration, int year)
        {
            var headerValue = GetHeader(configuration);
            var url = $"{GetUrl("GET_BY_YEAR",configuration)}{year}";

            var cars = _httpClient.Get(url, headerValue, "BASIC");

            return _toyotaMapper.MapCarsToDomain(cars);     
        }

        public IList<Car> GetById(ToyotaConfiguration configuration, int id)
        {
            var headerValue = GetHeader(configuration);
            var url = $"{GetUrl("GET_BY_ID",configuration)}{id}";

            var cars = _httpClient.Get(url, headerValue, "BASIC");

            return _toyotaMapper.MapCarsToDomain(cars);     
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