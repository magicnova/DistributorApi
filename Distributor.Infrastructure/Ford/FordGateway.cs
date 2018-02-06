using System.Collections.Generic;
using Distributor.Domain;
using Distributor.Domain.Common.ExtensionMethods;
using Distributor.Domain.Configuration;
using Distributor.Infrastructure.Data.Configuration;
using Distributor.Infrastructure.Ford.Interfaces;
using Microsoft.Extensions.Options;

namespace Distributor.Infrastructure.Ford
{
    public class FordGateway : IBrandGateway
    {
        private readonly IFordProxy _fordProxy;
        private readonly IConfigurationRepository _configurationRepository;
        private IOptions<FordConfiguration> _configuration;

        public FordGateway(IOptions<FordConfiguration> configuration, IConfigurationRepository configurationRepository, IFordProxy fordProxy)
        {
            _configuration = configuration;
            _configurationRepository = configurationRepository;
            _fordProxy = fordProxy;
        }

        public IList<Car> GetAll()
        {
            _configuration.Value.Credentials = _configurationRepository.GetFordConfiguration();
            return _fordProxy.GetAll(_configuration.Value);
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