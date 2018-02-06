using System.Collections.Generic;

namespace Distributor.Domain.Configuration
{
    public class FordConfiguration
    {
        public string BaseUrl { get; set; }
        public Dictionary<string,string> Actions { get; set; }
        public  Dictionary<string, string> Credentials { get; set; }
    }
}