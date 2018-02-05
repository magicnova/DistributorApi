using System.Collections.Generic;
using Distributor.Domain;
using Distributor.Infrastructure.Ford.Interfaces;

namespace Distributor.Infrastructure.Ford
{
    public class FordProxy : IFordProxy
    {
        public IList<Car> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}