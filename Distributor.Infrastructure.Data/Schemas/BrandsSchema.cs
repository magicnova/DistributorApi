using MongoDB.Bson;

namespace Distributor.Infrastructure.Data.Schemas
{
    public class BrandsSchema
    {
        public ObjectId Id { get; set; }
        public int BrandId { get; set; }
        public bool Active { get; set; }
    }
}