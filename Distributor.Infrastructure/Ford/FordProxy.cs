using System;
using System.Collections.Generic;
using System.Text;
using Distributor.Domain;
using Distributor.Domain.Configuration;
using Distributor.Infrastructure.Common.HttpClient;
using Distributor.Infrastructure.Ford.Interfaces;
using MongoDB.Driver.Core.Operations;

namespace Distributor.Infrastructure.Ford
{
    public class FordProxy : IFordProxy
    {
        private readonly IHttpClient _httpClient;
        private readonly IFordMapper _fordMapper;

        public FordProxy(IFordMapper fordMapper, IHttpClient httpClient)
        {
            _fordMapper = fordMapper;
            _httpClient = httpClient;
        }

        public IList<Car> GetAll(FordConfiguration configuration)
        {
            var headerValue = GetHeader(configuration);
            var url = GetUrl("GET_ALL",configuration);

            var cars = _httpClient.Get(url, headerValue, "Bearer");

            return _fordMapper.MapCarsToDomain(cars);
        }

        public IList<Car> GetByModel(FordConfiguration configuration, string model)
        {
            var headerValue = GetHeader(configuration);
            var url = $"{GetUrl("GET_BY_MODEL",configuration)}{model}";


            var cars = _httpClient.Get(url, headerValue, "Bearer");

            return _fordMapper.MapCarsToDomain(cars);
        }

        public IList<Car> GetByGearBox(FordConfiguration configuration, string gearBox)
        {
            var headerValue = GetHeader(configuration);
            var url = $"{GetUrl("GET_BY_GEARBOX",configuration)}{gearBox}";

            var cars = _httpClient.Get(url, headerValue, "Bearer");

            return _fordMapper.MapCarsToDomain(cars);
        }

        public IList<Car> GetByMotor(FordConfiguration configuration, string engine)
        {
            var headerValue = GetHeader(configuration);
            var url = $"{GetUrl("GET_BY_ENGINE",configuration)}{engine}";

            var cars = _httpClient.Get(url, headerValue, "Bearer");

            return _fordMapper.MapCarsToDomain(cars);
        }

        public IList<Car> GetByYear(FordConfiguration configuration, int year)
        {
            var headerValue = GetHeader(configuration);
            var url = $"{GetUrl("GET_BY_YEAR",configuration)}{year}";

            var cars = _httpClient.Get(url, headerValue, "Bearer");

            return _fordMapper.MapCarsToDomain(cars);
        }

        public Car GetById(FordConfiguration configuration, int id)
        {
            var headerValue = GetHeader(configuration);
            var url = $"{GetUrl("GET_BY_ID",configuration)}{id}";

            var cars = _httpClient.Get(url, headerValue, "Bearer");

            return _fordMapper.MapCarToDomain(cars);
        }
        
        private string GetUrl(string action, FordConfiguration configuration)
        {
            var baseUrl = configuration.BaseUrl;
            var actionUrl = configuration.Actions[action];

            var url = $"{baseUrl}{actionUrl}";
            return url;
        }

        private string GetHeader(FordConfiguration configuration)
        {
            return configuration.Credentials["TOKEN"];
        }
    }
}