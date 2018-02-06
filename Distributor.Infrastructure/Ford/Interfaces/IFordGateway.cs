using Distributor.Domain.Requests;

namespace Distributor.Infrastructure.Ford.Interfaces
{
    public interface IFordGateway
    {
        int Create(CarRequest car);
        int Update(CarRequest car);
        int Delete(string id);
    }
}