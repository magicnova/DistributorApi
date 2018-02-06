using System.Collections.Generic;
using Distributor.Domain;

namespace Distributor.Infrastructure.Ford.Interfaces
{
    public interface IFordMapper
    {
        IList<Car> MapJsonToDomain(string json);
    }
}