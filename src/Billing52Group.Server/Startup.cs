using AutoMapper;
using Billing52Group.Server.Configuration;
using Billing52Group.Server.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using MySql.Data.MySqlClient;

namespace Billing52Group.Server
{
    public class Startup
    {
        readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) => _configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(opt => opt.LowercaseUrls = true);
            services
                .AddControllers()
                .AddNewtonsoftJson(opt =>
                {
                    opt.UseCamelCasing(true);
                });

            services.AddDbContext<Billing52GroupContext>(opt =>
                opt.UseMySql(GetValidatedConnectionString()));

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo {Title = "Billing52Group API", Version = "v1"});

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
            });

            services.AddAutoMapper(typeof(Program));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                opt.RoutePrefix = "swagger";
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        string GetValidatedConnectionString()
        {
            var connectionString = _configuration[AppConstants.Configurations.ConnectionString];
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new MissingConfigurationMemberException(AppConstants.Configurations.ConnectionString);

            return connectionString;
        }
    }
}
