using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Distributor.Domain;
using Distributor.Domain.Common.ExtensionMethods;
using Distributor.Domain.Common.Interfaces;
using Distributor.Domain.Interfaces;
using Distributor.Infrastructure;

namespace Distributor.Service
{
    public class DistributorService : IDistributorService
    {
        private readonly IObjectFactory _objectFactory;

        public DistributorService(IObjectFactory objectFactory)
        {
            _objectFactory = objectFactory;
        }

        public IList<Car> GetAll()
        {
            var brands = new List<Brands> {Brands.Ford, Brands.Toyota};
            var brandCars = new List<Car>();
            
            Parallel.ForEach(brands, brand =>
            {
                var brandGateway = _objectFactory.Create<IBrandGateway>(brand.GetDesctiption());
               var cars = brandGateway.GetAll();
                brandCars = brandCars.Union(cars).ToList();
            });

            return brandCars;
        }

        public IList<Car> GetByModel(string brand, string model)
        {
            var brandGateway = _objectFactory.Create<IBrandGateway>(brand);
            return brandGateway.GetByModel(model);
        }

        public IList<Car> GetByTransmission(string brand, string transmission)
        {
            var brandGateway = _objectFactory.Create<IBrandGateway>(brand);
            return brandGateway.GetByTransmission(transmission);
        }

        public IList<Car> GetByEngine(string brand, string engine)
        {
            var brandGateway = _objectFactory.Create<IBrandGateway>(brand);
            return brandGateway.GetByEngine(engine);
        }

        public IList<Car> GetByYear(string brand, int year)
        {
            var brandGateway = _objectFactory.Create<IBrandGateway>(brand);
            return brandGateway.GetByYear(year);
        }

        public Car GetById(string brand, string id)
        {
            var brandGateway = _objectFactory.Create<IBrandGateway>(brand);
            return brandGateway.GetById(id);
        }
    }
}