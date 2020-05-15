using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dimng.Service;
using Dimng.ServiceInterface;
using Ding.Domain;
using Ding.Repository;
using Ding.RepositoryInterface;
using DingAPI.Middlewares;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DingAPI
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
            services.AddMvcCore().AddDataAnnotations();
            services.AddMvc(setup =>
            {

            }).AddFluentValidation();

            services.AddTransient<IValidator<ResponseModel>, ResponseModelValidator>();
            services.AddControllers().AddXmlSerializerFormatters();
            services.AddTransient<IMobileTopUpService, MobileTopUpService>();
            services.AddTransient<ITestRepository, TestRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ExceptionHandleMiddleware>();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
