using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Distributor.Domain;
using Distributor.Domain.Configuration;
using Distributor.Domain.Requests;
using Distributor.Infrastructure.Common.HttpClient;
using Distributor.Infrastructure.Ford.Interfaces;
using Microsoft.Win32.SafeHandles;
using MongoDB.Driver.Core.Operations;
using Newtonsoft.Json;

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

        public Car GetById(FordConfiguration configuration, string id)
        {
            var headerValue = GetHeader(configuration);
            var url = $"{GetUrl("GET_BY_ID",configuration)}{id}";

            var cars = _httpClient.Get(url, headerValue, "Bearer");

            return _fordMapper.MapCarToDomain(cars);
        }

        public int Create(CarRequest car, FordConfiguration configuration)
        {
            var headerValue = GetHeader(configuration);
            var url = $"{GetUrl("CREATE",configuration)}"; 
            var content= new  StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");

            var result = _httpClient.Post(url, content, "Bearer", headerValue);
              return (int)result.StatusCode;
        }

        public int Update(CarRequest car, FordConfiguration configuration)
        {
            var headerValue = GetHeader(configuration);
            var url = $"{GetUrl("UPDATE",configuration)}"; 
            var content= new  StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");

            var result = _httpClient.Put(url, content, "Bearer", headerValue);
            return (int)result.StatusCode;
        }

        public int Delete(string id, FordConfiguration configuration)
        {
            var headerValue = GetHeader(configuration);
            var url = $"{GetUrl("DELETE",configuration)}{id}";
            var result = _httpClient.Delete(url, "Bearer", headerValue);
            return (int)result.StatusCode;
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