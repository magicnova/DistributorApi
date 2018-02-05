using Autofac;
using Distributor.Domain.Interfaces;
using Distributor.Service;

namespace Distributor.IoC
{
    public class AutofacContainer : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DistributorService>().As<IDistributorService>();

        }
    }
}