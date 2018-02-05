namespace Distributor.Infrastructure.Common.ObjectFactory
{
    public interface IObjectFactory
    {
        T Create<T>(string clave) where T : class;
    }
}