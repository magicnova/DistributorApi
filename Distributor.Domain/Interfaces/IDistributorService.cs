using System.Collections.Generic;
using Distributor.Domain.Requests;

namespace Distributor.Domain.Interfaces
{
    public interface IDistributorService
    {
        IList<Car> GetAll();
        IList<Car> GetByModel(string brand, string model);
        IList<Car> GetByTransmission(string brand, string transmission);
        IList<Car> GetByEngine(string brand, string engine);
        IList<Car> GetByYear(string brand, int year);
        Car GetById(string brand, string id);
    }
}