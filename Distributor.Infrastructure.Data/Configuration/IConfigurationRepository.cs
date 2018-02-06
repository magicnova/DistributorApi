using System.Collections.Generic;

namespace Distributor.Infrastructure.Data.Configuration
{
    public interface IConfigurationRepository
    {
        Dictionary<string, string> GetToyotaConfiguration();
        Dictionary<string, string> GetFordConfiguration();
    }
}