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

        public IList<Car> GetByModel(string model)
        {
            throw new System.NotImplementedException();
        }

        public IList<Car> GetByTransmission(string transmission)
        {
            throw new System.NotImplementedException();
        }

        public IList<Car> GetByEngine(string engine)
        {
            throw new System.NotImplementedException();
        }

        public IList<Car> GetByYear(int year)
        {
            throw new System.NotImplementedException();
        }

        public Car GetById(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}