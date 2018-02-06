using System.Collections.Generic;
using System.Linq;
using Distributor.Domain;
using Distributor.Domain.Common.ExtensionMethods;
using Distributor.Infrastructure.Toyota.Interfaces;
using Newtonsoft.Json.Linq;

namespace Distributor.Infrastructure.Toyota
{
    public class ToyotaMapper : IToyotaMapper
    {
        public IList<Car> MapCarsToDomain(string json)
        {
            return JArray.Parse(json).Select(car =>
                new Car
                {
                    Brand = Brands.Toyota.GetDesctiption(),
                    Motor = car["engine"].ToString(),
                    Active = true,
                    Id = car["id"].ToString(),
                    Model = car["model"].ToString(),
                    Transmission = car["transmission"].ToString(),
                    Year = (int) car["year"]
                }).ToList();
        }

        public Car MapCarToDomain(string json)
        {
            var car = JObject.Parse(json);
            return new Car
            {
                Brand = Brands.Toyota.GetDesctiption(),
                Motor = car["engine"].ToString(),
                Active =true,
                Id = car["id"].ToString(),
                Model = car["model"].ToString(),
                Transmission = car["transmission"].ToString(),
                Year = (int) car["year"]
            };
        }
    }
}