using System.Collections.Generic;
using System.Xml.Linq;
using Distributor.Domain;
using Distributor.Infrastructure.Ford.Interfaces;

namespace Distributor.Infrastructure.Ford
{
    public class FordMapper : IFordMapper
    {
        public IList<Car> MapJsonToDomain(string json)
        {
            return new List<Car>();
        }
    }
}