using AcademyD.Demo1.Core.BusinessLayer;
using AcademyD.Demo1.Core.Interfaces;
using AcademyD.Demo1.Core.Mock.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AcademyD.Demo3.AspNETCore_WebApi
{
    public class Startup
    {
        // sfruttiamo la Reflection
        public readonly string ApplicationName =
            Assembly.GetEntryAssembly().GetName().Name;

        public readonly string ApplicationVersion =
            $"v{Assembly.GetEntryAssembly().GetName().Version.Major}" +
            $".{Assembly.GetEntryAssembly().GetName().Version.Minor}" +
            $".{Assembly.GetEntryAssembly().GetName().Version.Build}";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<IMainBusinessLayer, MainBusinessLayer>();
            //services.AddTransient<IEmployeeRepository, MockEmployeeRepository>();
            //services.AddScoped<IEmployeeRepository, MockEmployeeRepository>();

            // Utilizzo l'AddSingleton per comodita' perche' l’istanza mock viene creata alla prima necessità di iniezione e poi conservata
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();

            services.AddControllers();


            // Configurazione Swagger
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = ApplicationName,
                    Version = ApplicationVersion
                });

                string file = $"{ApplicationName}.xml";
                options.IncludeXmlComments(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file)
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Swagger middleware
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(
                    "v1/swagger.json",
                    $"{ApplicationName} {ApplicationVersion}"
                );
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
