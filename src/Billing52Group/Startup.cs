using AutoMapper;
using Billing52Group.Areas.Identity;
using Billing52Group.Configuration;
using Billing52Group.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Billing52Group
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

            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseMySql(GetValidatedConnectionString()));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services
                .AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

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

                app.UseSwagger();
            }

            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                opt.RoutePrefix = "swagger";
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
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
