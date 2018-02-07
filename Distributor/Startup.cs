using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Autofac;
using Distributor.Domain.Configuration;
using Distributor.IoC;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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
            services.AddAuthentication(AuthConfig)
                .AddJwtBearer("JwtBearer", JwtBearerOptions);
        }

        private void AuthConfig(AuthenticationOptions options)
        {
            options.DefaultAuthenticateScheme = "JwtBearer";
            options.DefaultChallengeScheme = "JwtBearer";
        }

        private void JwtBearerOptions(JwtBearerOptions jwtBearerOptions)
        {
            jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")),
                ValidateIssuer = true,
                ValidIssuer = "German",
                ValidateAudience = true,
                ValidAudience = "German",
                ValidateLifetime = true
            };
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacContainer(Configuration));
        }
    
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}