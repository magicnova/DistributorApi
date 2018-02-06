using System.Collections.Generic;
using Distributor.Domain;
using Distributor.Domain.Common.ExtensionMethods;

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
                    Brand = Brands.Ford.GetDesctiption()
                }
            };
        }
    }
}