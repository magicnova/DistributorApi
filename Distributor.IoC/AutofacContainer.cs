using Autofac;
using Distributor.Domain;
using Distributor.Domain.Common.ExtensionMethods;
using Distributor.Domain.Common.Interfaces;
using Distributor.Domain.Interfaces;
using Distributor.Infrastructure;
using Distributor.Infrastructure.Common.ObjectFactory;
using Distributor.Infrastructure.Ford;
using Distributor.Infrastructure.Ford.Interfaces;
using Distributor.Infrastructure.Toyota;
using Distributor.Infrastructure.Toyota.Interfaces;
using Distributor.Service;

namespace Distributor.IoC
{
    public class AutofacContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ObjectFactory>().As<IObjectFactory>();
            
            builder.RegisterType<DistributorService>().As<IDistributorService>();

            builder.RegisterType<FordGateway>().Named<IBrandGateway>(Brands.Ford.GetDesctiption());
            builder.RegisterType<ToyotaGateway>().Named<IBrandGateway>(Brands.Toyota.GetDesctiption());
            builder.RegisterType<FordProxy>().As<IFordProxy>();
            builder.RegisterType<ToyotaProxy>().As<IToyotaProxy>();

        }
    }
}