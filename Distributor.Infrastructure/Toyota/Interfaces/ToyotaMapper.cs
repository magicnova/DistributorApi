using System.Collections.Generic;
using Distributor.Domain;

namespace Distributor.Infrastructure.Toyota.Interfaces
{
    public class ToyotaMapper : IToyotaMapper
    {
        public IList<Car> MapCarsToDomain(string json)
        {
            throw new System.NotImplementedException();
        }

        public Car MapCarToDomain(string json)
        {
            throw new System.NotImplementedException();
        }
    }
}