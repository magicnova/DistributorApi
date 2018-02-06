using System.Collections.Generic;
using System.Linq;
using Distributor.Domain;
using Distributor.Domain.Common.ExtensionMethods;
using Distributor.Infrastructure.Ford.Interfaces;
using Newtonsoft.Json.Linq;

namespace Distributor.Infrastructure.Ford
{
    public class FordMapper : IFordMapper
    {
        public IList<Car> MapCarsToDomain(string json)
        {
            return JArray.Parse(json).Select(car =>
                new Car
                {
                    Brand = Brands.Ford.GetDesctiption(),
                    Motor = car["motor"].ToString(),
                    Active = (bool) car["active"],
                    Id = car["id"].ToString(),
                    Model = car["model"].ToString(),
                    Transmission = car["gearBox"].ToString(),
                    Year = (int) car["year"]
                }).ToList();
        }

        public Car MapCarToDomain(string json)
        {
            var car = JObject.Parse(json);
            return new Car
            {
                Brand = Brands.Ford.GetDesctiption(),
                Motor = car["motor"].ToString(),
                Active = (bool) car["active"],
                Id = car["id"].ToString(),
                Model = car["model"].ToString(),
                Transmission = car["gearBox"].ToString(),
                Year = (int) car["year"]
            };
        }
    }
}