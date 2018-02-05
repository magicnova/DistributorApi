using System.Collections.Generic;
using Distributor.Domain;

namespace Distributor.Infrastructure.Ford
{
    public class FordGateway :IBrandGateway
    {
        public IList<Car> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}