using Autofac;
using Distributor.Domain.Interfaces;
using Distributor.Infrastructure;
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
            builder.RegisterType<DistributorService>().As<IDistributorService>();

            builder.RegisterType<FordGateway>().Named<IBrandGateway>("Ford");
            builder.RegisterType<ToyotaGateway>().Named<IBrandGateway>("Toyota");
            builder.RegisterType<FordProxy>().As<IFordProxy>();
            builder.RegisterType<ToyotaProxy>().As<IToyotaProxy>();

        }
    }
}