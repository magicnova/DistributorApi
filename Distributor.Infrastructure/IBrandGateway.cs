using System.Collections.Generic;
using Distributor.Domain;

namespace Distributor.Infrastructure
{
    public interface IBrandGateway
    {
        IList<Car> GetAll();
    }
}