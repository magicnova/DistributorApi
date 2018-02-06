using System.Collections.Generic;

namespace Distributor.Domain.Configuration
{
    public class ToyotaConfiguration
    {
        public string BaseUrl { get; set; }
        public Dictionary<string,string> Actions { get; set; }
        public  Dictionary<string, string> Credentials { get; set; }
    }
}