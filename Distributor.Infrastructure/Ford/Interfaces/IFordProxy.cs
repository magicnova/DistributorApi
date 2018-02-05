using System.Collections.Generic;
using Distributor.Domain;

namespace Distributor.Infrastructure.Ford.Interfaces
{
    public interface IFordProxy
    {
        IList<Car> GetAll();
    }
}