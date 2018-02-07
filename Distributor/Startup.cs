using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Autofac;
using Distributor.Domain.Configuration;
using Distributor.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Distributor
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("Config/appsettings.Development.json", optional: false, reloadOnChange: true)
                .AddJsonFile("Config/proxysettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ToyotaConfiguration>(
                (Options) =>
                {
                    Options.BaseUrl = Configuration.GetSection("apiToyota:url").Value;
                    Options.Actions = Configuration.GetSection("apiToyota:actions").GetChildren()
                        .Select(item => new KeyValuePair<string, string>(item.Key, item.Value))
                        .ToDictionary(x => x.Key, x => x.Value);
                }
            );
            
            services.Configure<FordConfiguration>(
                (Options) =>
                {
                    Options.BaseUrl = Configuration.GetSection("apiFord:url").Value;
                    Options.Actions = Configuration.GetSection("apiFord:actions").GetChildren()
                        .Select(item => new KeyValuePair<string, string>(item.Key, item.Value))
                        .ToDictionary(x => x.Key, x => x.Value);
                }
            );
            services.AddMvc();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacContainer(Configuration));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}