using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using TipoCambio.Service.Api.Services;
using System.Reflection;
using TipoCambio.Service.Api.Data.DapperConexion;
using TipoCambio.Service.Api.Data.DapperConexion.CurrencyExchange;

namespace TipoCambio.Service.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddCors();

            services.AddOptions();
            services.Configure<ConexionConfiguracion>(Configuration.GetSection("ConnectionStrings"));


            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IFactoryConnection, FactoryConnection>();
            services.AddScoped<ICurrencyExchangeRepository, CurrencyExchangeRepository>();
            services.AddScoped<ICurrencyExchangeService, CurrencyExchangeService>();
            services.AddControllers();

            services.AddTokenAuthentication(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
