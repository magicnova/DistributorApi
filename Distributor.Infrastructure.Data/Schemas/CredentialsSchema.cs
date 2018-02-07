using MongoDB.Bson;

namespace Distributor.Infrastructure.Data.Schemas
{
    public class CredentialsSchema
    {
        public ObjectId Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}