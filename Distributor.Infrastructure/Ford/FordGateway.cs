using System.Collections.Generic;
using Distributor.Domain;

namespace Distributor.Infrastructure.Ford
{
    public class FordGateway : IBrandGateway
    {
        public IList<Car> GetAll()
        {
            return new List<Car>
            {
                new Car
                {
                    Brand = Brands.Ford
                }
            };
        }
    }
}