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

        public void Create(CarRequest car)
        {
            _fordGateway.Create(car);
        }
        
        public void Update(CarRequest car)
        {
            _fordGateway.Update(car);
        }

        public void Delete(string id)
        {
            _fordGateway.Delete(id);
        }
    }
}