using System.Collections.Generic;
using Distributor.Domain;
using Distributor.Domain.Configuration;

namespace Distributor.Infrastructure.Toyota.Interfaces
{
    public interface IToyotaProxy
    {
        IList<Car> GetAll(ToyotaConfiguration configuration);
    }
}