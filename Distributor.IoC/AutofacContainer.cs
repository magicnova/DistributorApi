using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Distributor.Domain;
using Distributor.Domain.Common.ExtensionMethods;
using Distributor.Domain.Common.Interfaces;
using Distributor.Domain.Interfaces;
using Distributor.Infrastructure;
using Distributor.Infrastructure.Common.HttpClient;
using Distributor.Infrastructure.Common.ObjectFactory;
using Distributor.Infrastructure.Data;
using Distributor.Infrastructure.Data.Configuration;
using Distributor.Infrastructure.Data.Context;
using Distributor.Infrastructure.Data.Context.Interfaces;
using Distributor.Infrastructure.Ford;
using Distributor.Infrastructure.Ford.Interfaces;
using Distributor.Infrastructure.Toyota;
using Distributor.Infrastructure.Toyota.Interfaces;
using Distributor.Service;
using Microsoft.Extensions.Configuration;

namespace Distributor.IoC
{
    public class AutofacContainer : Module
    {
        private IConfiguration _configuration;
        public AutofacContainer(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ObjectFactory>().As<IObjectFactory>();
            builder.RegisterType<DistributorContext>().As<IDistributorContext>()
                .WithParameters(new List<Parameter>
                {
                     new NamedParameter("connectionString",_configuration.GetSection("MongoConnection:ConnectionString").Value),
                     new NamedParameter("database",_configuration.GetSection("MongoConnection:Database").Value),
                });
            builder.RegisterType<ConfigurationRepository>().As<IConfigurationRepository>();
            builder.RegisterType<HttpClient>().As<IHttpClient>();
            builder.RegisterType<DistributorService>().As<IDistributorService>();

            builder.RegisterType<FordGateway>().Named<IBrandGateway>(Brands.Ford.GetDesctiption())
                .As<IFordGateway>();
            builder.RegisterType<FordProxy>().As<IFordProxy>();
            builder.RegisterType<FordMapper>().As<IFordMapper>();

            builder.RegisterType<ToyotaGateway>()
                .Named<IBrandGateway>(Brands.Toyota.GetDesctiption());
            
            builder.RegisterType<ToyotaProxy>().As<IToyotaProxy>();
            builder.RegisterType<ToyotaMapper>().As<IToyotaMapper>();

            builder.RegisterType<FordService>().As<IFordService>();
        }
    }
}