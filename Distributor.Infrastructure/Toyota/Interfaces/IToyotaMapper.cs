using System.Collections.Generic;
using Distributor.Domain;

namespace Distributor.Infrastructure.Toyota.Interfaces
{
    public interface IToyotaMapper
    {
        IList<Car> MapCarsToDomain(string json);
        Car MapCarToDomain(string json);
    }
}