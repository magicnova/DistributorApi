namespace Distributor.Infrastructure.Common.HttpClient
{
    public interface IHttpClient
    {
        string Get(string url, string headerValue, string schema);
    }
}