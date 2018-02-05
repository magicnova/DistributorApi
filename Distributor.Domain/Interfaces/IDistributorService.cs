using System.Collections.Generic;

namespace Distributor.Domain.Interfaces
{
    public interface IDistributorService
    {
        IList<Car> GetAll();
    }
}