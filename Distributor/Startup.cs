using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Autofac;
using Distributor.Domain.Configuration;
using Distributor.IoC;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

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
            
            services.AddSwaggerGen(swagger =>
            {
                swagger.AddSecurityDefinition("Bearer", new ApiKeyScheme() { In = "Header", Description = "Please insert JWT with Bearer into field", Name = "Authorization", Type = "apiKey" });
                swagger.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath,
                    "Distributor.xml"));
                swagger.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Distributor API",
                        Version = "v1",
                        Description =
                            "This API will return cars made by Ford ,Toyota. Create,update, delete is available only for Ford . Mongo database is required"
                    });
                swagger.OrderActionsBy(sort => sort.GroupName);
            });
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
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Distributor API V1"); });
        }
    }
}