using System.Collections.Generic;
using Distributor.Domain;

namespace Distributor.Infrastructure.Toyota
{
    public class ToyotaGateway: IBrandGateway
    {
        public IList<Car> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}