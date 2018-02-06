using System.Collections.Generic;

namespace Distributor.Infrastructure.Data.Configuration
{
    public class ConfigurationRepository :IConfigurationRepository
    {
       public Dictionary<string, string> GetToyotaConfiguration()
       {
           var credentials = new Dictionary<string, string> {{"USERNAME", "USUARIO"}, 
               {"PASSWORD", "123456"}};

           return credentials;
       }

        public Dictionary<string, string> GetFordConfiguration()
        {
            var credentials = new Dictionary<string, string> {{"TOKEN", "U123"}};
            return credentials;
        }
    }
}