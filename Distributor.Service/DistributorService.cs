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

    }
}