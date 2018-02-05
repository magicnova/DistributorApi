using System.Collections.Generic;
using Distributor.Domain;
using Distributor.Domain.Interfaces;

namespace Distributor.Service
{
    public class DistributorService : IDistributorService
    {
        public IList<Car> GetAll()
        {
            
            return new List<Car>();
        }
    }
}