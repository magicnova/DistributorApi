using System.Collections.Generic;
using Distributor.Domain;
using Distributor.Domain.Configuration;
using Distributor.Domain.Requests;

namespace Distributor.Infrastructure.Ford.Interfaces
{
    public interface IFordProxy
    {
        IList<Car> GetAll(FordConfiguration configuration);
        IList<Car> GetByModel(FordConfiguration configuration, string model);
        IList<Car> GetByGearBox(FordConfiguration configuration, string gearBox);
        IList<Car> GetByMotor(FordConfiguration configuration, string engine);
        IList<Car> GetByYear(FordConfiguration configuration, int year);
        Car GetById(FordConfiguration configuration, string id);
        int Create(CarRequest car, FordConfiguration configurationValue);
        int Update(CarRequest car, FordConfiguration configuration);
        int Delete(string id, FordConfiguration configuration);
    }
}