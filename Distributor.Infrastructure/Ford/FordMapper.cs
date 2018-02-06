﻿using System.Collections.Generic;
using Distributor.Domain;
using Distributor.Domain.Common.ExtensionMethods;
using Distributor.Infrastructure.Ford.Interfaces;
using Newtonsoft.Json.Linq;

namespace Distributor.Infrastructure.Ford
{
    public class FordMapper : IFordMapper
    {
        public IList<Car> MapJsonToDomain(string json)
        {
            var  jCars = JArray.Parse(json);
            var cars = new List<Car>();
            foreach (var car in jCars)
            {
                cars.Add(new Car
                {
                    Brand = Brands.Ford.GetDesctiption(),
                    Motor = car["motor"].ToString()
                });
            }

            return cars;
        }
    }
}