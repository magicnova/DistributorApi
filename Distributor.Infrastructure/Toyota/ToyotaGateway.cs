using System.Collections.Generic;
using Distributor.Domain;

namespace Distributor.Infrastructure.Toyota
{
    public class ToyotaGateway: IBrandGateway
    {
        public IList<Car> GetAll()
        {
            return new List<Car>
            {
                new Car
                {
                    Brand = Brands.Toyota
                }
            };
        }
    }
}