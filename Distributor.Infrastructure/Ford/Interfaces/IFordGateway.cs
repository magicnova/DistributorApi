using Distributor.Domain.Requests;

namespace Distributor.Infrastructure.Ford.Interfaces
{
    public interface IFordGateway
    {
        int Create(CarRequest car);
        void Update(CarRequest car);
        void Delete(string id);
    }
}