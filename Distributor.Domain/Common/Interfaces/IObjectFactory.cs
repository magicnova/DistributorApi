namespace Distributor.Domain.Common.Interfaces
{
    public interface IObjectFactory
    {
           T Create<T>(string clave) where T : class;    
    }
}