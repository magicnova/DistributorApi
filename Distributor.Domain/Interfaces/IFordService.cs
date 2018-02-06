using Distributor.Domain.Requests;

namespace Distributor.Domain.Interfaces
{
    public interface IFordService
    {
        int Create(CarRequest car);
        void Update(CarRequest car);
        void Delete(string id);
    }
}