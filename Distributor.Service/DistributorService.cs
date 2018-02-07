using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Distributor.Domain;
using Distributor.Domain.Common.ExtensionMethods;
using Distributor.Domain.Common.Interfaces;
using Distributor.Domain.Interfaces;
using Distributor.Domain.Requests;
using Distributor.Infrastructure;
using Distributor.Infrastructure.Data.Brand;

namespace Distributor.Service
{
    public class DistributorService : IDistributorService
    {
        private readonly IObjectFactory _objectFactory;
        private readonly IBrandsRepository _brandsRepository;
        public DistributorService(IObjectFactory objectFactory, IBrandsRepository brandsRepository)
        {
            _objectFactory = objectFactory;
            _brandsRepository = brandsRepository;
        }

        public IList<Car> GetAll()
        {
            var brands = _brandsRepository.GetActiveBrands();
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
            brand = NormalizeBrand(brand);
            var brandGateway = _objectFactory.Create<IBrandGateway>(brand);
            return brandGateway.GetByModel(model);
        }

        public IList<Car> GetByTransmission(string brand, string transmission)
        {https://bitbucket.org/patao/seleccion-netcore
            brand = NormalizeBrand(brand);
            var brandGateway = _objectFactory.Create<IBrandGateway>(brand);
            return brandGateway.GetByTransmission(transmission);
        }

        public IList<Car> GetByEngine(string brand, string engine)
        {
            brand = NormalizeBrand(brand);
            var brandGateway = _objectFactory.Create<IBrandGateway>(brand);
            return brandGateway.GetByEngine(engine);
        }

        public IList<Car> GetByYear(string brand, int year)
        {
            brand = NormalizeBrand(brand);
            var brandGateway = _objectFactory.Create<IBrandGateway>(brand);
            return brandGateway.GetByYear(year);
        }

        public Car GetById(string brand, string id)
        {
            brand = NormalizeBrand(brand);
            var brandGateway = _objectFactory.Create<IBrandGateway>(brand);
            return brandGateway.GetById(id);
        }

        private string NormalizeBrand(string brand)
        {
            return brand.ToLower().Contains("toyota") ? Brands.Toyota.GetDesctiption() : Brands.Ford.GetDesctiption();
        }

    }
}