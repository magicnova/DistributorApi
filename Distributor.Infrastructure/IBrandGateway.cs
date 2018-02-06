using System.Collections.Generic;
using Distributor.Domain;
using Distributor.Domain.Configuration;

namespace Distributor.Infrastructure
{
    public interface IBrandGateway
    {
        IList<Car> GetAll();
        IList<Car> GetByModel(string model);
        IList<Car> GetByTransmission(string transmission);
        IList<Car> GetByEngine(string engine);
        IList<Car> GetByYear(int year);
        Car GetById(string id);
    }
}