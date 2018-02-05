using System.Collections.Generic;
using Distributor.Domain;

namespace Distributor.Infrastructure.Toyota.Interfaces
{
    public interface IToyotaProxy
    {
        IList<Car> GetAll();
    }
}