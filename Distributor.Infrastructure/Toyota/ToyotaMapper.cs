using System.Collections.Generic;
using Distributor.Domain;
using Distributor.Domain.Common.ExtensionMethods;
using Distributor.Infrastructure.Toyota.Interfaces;
using Newtonsoft.Json.Linq;

namespace Distributor.Infrastructure.Toyota
{
    public class ToyotaMapper :IToyotaMapper
    {
        public IList<Car> MapCarsToDomain(string json)
        {
            var  jCars = JArray.Parse(json);
            var cars = new List<Car>();
            foreach (var car in jCars)
            {
                cars.Add(new Car
                {
                    Brand = Brands.Toyota.GetDesctiption(),
                    Motor = car["motor"].ToString()
                });
            }

            return cars;
        }

        public Car MapCarToDomain(string json)
        {
            throw new System.NotImplementedException();
        }
    }
}