using System;
using System.IO;
using Domain.StoreContext.Handlers;
using Domain.StoreContext.Repositories;
using Domain.StoreContext.Services;
using Elmah.Io.AspNetCore;
using Infra.StoreContext.DataContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Infra.StoreContext.Repositories;
using Infra.StoreContext.Services;
using Microsoft.Extensions.Configuration;
using Shared;
using Swashbuckle.AspNetCore.Swagger;

namespace API
{
    public class Startup
    {
        public static IConfiguration Configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json");

            Configuration = builder.Build();

            services.AddMvc();
            services.AddResponseCompression();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<CustomerHandler, CustomerHandler>();
            services.AddTransient<IEmailService, EmailService>();

            services.AddScoped<DataContext, DataContext>();
            services.AddSwaggerGen( x => 
                x.SwaggerDoc("v1", new Info { Title = "Store", Version = "v1"}));
            services.AddElmahIo(o =>
            {
                o.ApiKey = "acf599d8bb9e42238e1a6af6244073d4";
                o.LogId = new Guid("03120ebd-ad21-4943-8903-6770a1d9a54e");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store - V1"); });
            app.UseElmahIo();
        }
    }
}
