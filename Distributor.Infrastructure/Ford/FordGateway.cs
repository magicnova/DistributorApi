using System.Collections.Generic;
using Distributor.Domain;
using Distributor.Domain.Common.ExtensionMethods;
using Distributor.Domain.Configuration;
using Distributor.Domain.Requests;
using Distributor.Infrastructure.Data.Configuration;
using Distributor.Infrastructure.Ford.Interfaces;
using Microsoft.Extensions.Options;

namespace Distributor.Infrastructure.Ford
{
    public class FordGateway : IBrandGateway,IFordGateway
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
            _configuration.Value.Credentials = _configurationRepository.GetFordConfiguration();
            return _fordProxy.GetByModel(_configuration.Value,model);
        }

        public IList<Car> GetByTransmission(string transmission)
        {
            _configuration.Value.Credentials = _configurationRepository.GetFordConfiguration();
            return _fordProxy.GetByGearBox(_configuration.Value,transmission);
        }

        public IList<Car> GetByEngine(string engine)
        {
            _configuration.Value.Credentials = _configurationRepository.GetFordConfiguration();
            return _fordProxy.GetByMotor(_configuration.Value,engine);
        }

        public IList<Car> GetByYear(int year)
        {
            _configuration.Value.Credentials = _configurationRepository.GetFordConfiguration();
            return _fordProxy.GetByYear(_configuration.Value,year);
        }

        public Car GetById(string id)
        {
            _configuration.Value.Credentials = _configurationRepository.GetFordConfiguration();
            return _fordProxy.GetById(_configuration.Value,id);
        }

        public void Create(CarRequest car)
        {
            _configuration.Value.Credentials = _configurationRepository.GetFordConfiguration();
            _fordProxy.Create(car, _configuration.Value);
        }

        public void Update(CarRequest car)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}