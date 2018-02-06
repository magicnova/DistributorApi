using Distributor.Domain.Requests;

namespace Distributor.Domain.Interfaces
{
    public interface IFordService
    {
        int Create(CarRequest car);
        int Update(CarRequest car);
        int Delete(string id);
    }
}