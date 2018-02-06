using Distributor.Domain.Interfaces;
using Distributor.Domain.Requests;
using Distributor.Infrastructure.Ford.Interfaces;

namespace Distributor.Service
{
    public class FordService: IFordService
    {
        private readonly IFordGateway _fordGateway;
        public FordService(IFordGateway fordGateway)
        {
            _fordGateway = fordGateway;
        }

        public int Create(CarRequest car)
        {
            return _fordGateway.Create(car);
        }
        
        public int Update(CarRequest car)
        {
            return _fordGateway.Update(car);
        }

        public int Delete(string id)
        {
            return _fordGateway.Delete(id);
        }
    }
}