using System;
using System.Collections.Generic;
using Distributor.Infrastructure.Data.Context.Interfaces;
using Distributor.Infrastructure.Data.Schemas;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Distributor.Infrastructure.Data.Configuration
{
    public class ConfigurationRepository :IConfigurationRepository
    {
        private readonly IDistributorContext _distributorContext;

        public ConfigurationRepository(IDistributorContext distributorContext)
        {
            _distributorContext = distributorContext;
        }

        public Dictionary<string, string> GetToyotaConfiguration()
       {
           try
           {
               var filterUserKey = Builders<CredentialsSchema>.Filter.Eq("Key", "api.toyotapi.credentials.user");
               var filterPasswordKey = Builders<CredentialsSchema>.Filter.Eq("Key", "api.toyotapi.credentials.password");
                
               var user = _distributorContext.GetContext().GetCollection<CredentialsSchema>("credentials")
                   .Find(filterUserKey).FirstOrDefault();
               
               var password= _distributorContext.GetContext().GetCollection<CredentialsSchema>("credentials")
                   .Find(filterPasswordKey).FirstOrDefault();
        
               var credentials = new Dictionary<string, string> {{"USERNAME", user.Value}, 
                   {"PASSWORD", password.Value}};

               return credentials;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

        public Dictionary<string, string> GetFordConfiguration()
        {
           
            try
            {
                var filterTokenKey = Builders<CredentialsSchema>.Filter.Eq("Key", "api.fordapi.credentials.token");
                
                var token = _distributorContext.GetContext().GetCollection<CredentialsSchema>("credentials")
                    .Find(filterTokenKey).FirstOrDefault();

                var credentials = new Dictionary<string, string> {{"TOKEN", token.Value}};

                return credentials;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}