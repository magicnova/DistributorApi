using System.Collections.Generic;
using Distributor.Domain;
using Distributor.Infrastructure.Toyota.Interfaces;

namespace Distributor.Infrastructure.Toyota
{
    public class ToyotaProxy : IToyotaProxy
    {
        public IList<Car> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}