using System.Collections.Generic;
using Distributor.Domain;
using Distributor.Domain.Configuration;

namespace Distributor.Infrastructure.Toyota.Interfaces
{
    public interface IToyotaProxy
    {
        IList<Car> GetAll(ToyotaConfiguration configuration);
        IList<Car> GetByModel(ToyotaConfiguration configuration, string model);
        IList<Car> GetByTransmission(ToyotaConfiguration configuration, string transmission);
        IList<Car> GetByEngine(ToyotaConfiguration configuration, string engine);
        IList<Car> GetByYear(ToyotaConfiguration configuration, int year);
        IList<Car> GetById(ToyotaConfiguration configuration, int id);
        
    }
}