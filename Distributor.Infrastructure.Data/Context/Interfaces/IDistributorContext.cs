using MongoDB.Driver;

namespace Distributor.Infrastructure.Data.Context.Interfaces
{
    public interface IDistributorContext
    {
        IMongoDatabase GetContext();
    }
}