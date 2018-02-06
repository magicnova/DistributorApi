using System;
using System.Collections.Generic;
using Distributor.Domain;
using Distributor.Domain.Common.ExtensionMethods;
using Distributor.Domain.Configuration;
using Distributor.Infrastructure.Data.Configuration;
using Distributor.Infrastructure.Toyota.Interfaces;
using Microsoft.Extensions.Options;

namespace Distributor.Infrastructure.Toyota
{
    public class ToyotaGateway : IBrandGateway
    {
        private readonly IToyotaProxy _toyotaProxy;
        private readonly IConfigurationRepository _configurationRepository;
        private IOptions<ToyotaConfiguration> _configuration;
        public ToyotaGateway(IToyotaProxy toyotaProxy,IOptions<ToyotaConfiguration> configuration, IConfigurationRepository configurationRepository)
        {
            _configuration = configuration;
            _toyotaProxy = toyotaProxy;
            _configurationRepository = configurationRepository;
        }

        public IList<Car> GetAll()
        {
               _configuration.Value.Credentials =  _configurationRepository.GetToyotaConfiguration();
            return _toyotaProxy.GetAll(_configuration.Value);
        }
    }
}