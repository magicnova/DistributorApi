using System.Collections.Generic;
using Distributor.Domain;

namespace Distributor.Infrastructure.Ford.Interfaces
{
    public interface IFordMapper
    {
        IList<Car> MapCarsToDomain(string json);
        Car MapCarToDomain(string json);
    }
}