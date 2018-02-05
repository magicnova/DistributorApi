using Autofac;

namespace Distributor.Infrastructure.Common.ObjectFactory
{
    public class ObjectFactory:IObjectFactory
    {
        private readonly IComponentContext _container;
        
        public ObjectFactory(IComponentContext container)
        {
            _container = container;
        }


        public T Create<T>(string clave) where T:class
        {
            return _container.ResolveNamed<T>(clave);
        }   
    }
}