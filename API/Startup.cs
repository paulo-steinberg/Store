using Domain.StoreContext.Handlers;
using Domain.StoreContext.Repositories;
using Domain.StoreContext.Services;
using Infra.StoreContext.DataContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Infra.StoreContext.Repositories;
using Infra.StoreContext.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddResponseCompression();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<CustomerHandler, CustomerHandler>();
            services.AddTransient<IEmailService, EmailService>();

            services.AddScoped<DataContext, DataContext>();
            services.AddSwaggerGen( x => 
                x.SwaggerDoc("v1", new Info { Title = "Store", Version = "v1"}));
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
        }
    }
}
