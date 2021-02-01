using FluentValidation.Results;
using FluentValidation;
using GeolettApi.Application.Mapping;
using GeolettApi.Application.Models;
using GeolettApi.Application.Queries;
using GeolettApi.Application.Services.Authorization.GeoID;
using GeolettApi.Application.Services.Authorization;
using GeolettApi.Application.Services;
using GeolettApi.Application;
using GeolettApi.Domain.Models;
using GeolettApi.Domain.Repositories;
using GeolettApi.Infrastructure.DataModel.UnitOfWork;
using GeolettApi.Infrastructure.Repositories;
using GeolettApi.Web.Configuration;
using GeolettApi.Web.Extensions;
using Geonorge.TiltaksplanApi.Application.Validation;
using Geonorge.TiltaksplanApi.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Collections.Generic;
using GeolettApi.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace GeolettApi.Web
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables()
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddControllers().AddNewtonsoftJson();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "GeolettApi.Web", Version = "v1" });

                options.SchemaFilter<SwaggerExcludePropertySchemaFilter>();

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Fyll inn \"Bearer\" [space] og en token i tekstfeltet under. Eksempel: \"Bearer b990274d-2082-34a5-9768-02b396f98d8d\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            services.AddEntityFrameworkForGeolett(Configuration);
            services.AddLocalization(options => { options.ResourcesPath = "Resources"; });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<IUrlProvider, GeolettUrlProvider>();

            // Application services
            services.AddScoped<IUnitOfWorkManager, UnitOfWorkManager>();
            services.AddTransient<IRegisterItemService, RegisterItemService>();
            services.AddTransient<IGeoIDService, GeoIDService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<ISetupService, SetupService>();

            // Validators
            services.AddTransient<IValidator<RegisterItem>, RegisterItemValidator>();
            services.AddTransient<IValidator<DataSet>, DataSetValidator>();
            services.AddTransient<IValidator<Reference>, ReferenceValidator>();
            services.AddTransient<IValidator<ObjectType>, ObjectTypeValidator>();
            services.AddTransient<IValidator<Link>, LinkValidator>();

            // Queries
            services.AddTransient<IAsyncQuery<RegisterItemViewModel>, RegisterItemQuery>();
            services.AddTransient<IAsyncQuery<DataSetViewModel>, DataSetQuery>();

            // Repositories
            services.AddScoped<IRepository<RegisterItem, int>, RegisterItemRepository>();

            // Mappers
            services.AddTransient<IViewModelMapper<RegisterItem, RegisterItemViewModel>, RegisterItemViewModelMapper>();
            services.AddTransient<IViewModelMapper<DataSet, DataSetViewModel>, DataSetViewModelMapper>();
            services.AddTransient<IViewModelMapper<Reference, ReferenceViewModel>, ReferenceViewModelMapper>();
            services.AddTransient<IViewModelMapper<ObjectType, ObjectTypeViewModel>, ObjectTypeViewModelMapper>();
            services.AddTransient<IViewModelMapper<Link, LinkViewModel>, LinkViewModelMapper>();
            services.AddTransient<IViewModelMapper<RegisterItemLink, RegisterItemLinkViewModel>, RegisterItemLinkViewModelMapper>();
            
            // Configuration
            services.Configure<GeoIDConfiguration>(Configuration.GetSection(GeoIDConfiguration.SectionName));
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            ILoggerFactory loggerFactory,
            IHostApplicationLifetime hostApplicationLifetime)
        {
            loggerFactory.AddSerilog(Log.Logger, true);

            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            if (env.IsLocal() || env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                var url = $"{(!env.IsLocal() ? "/api" : "")}/swagger/v1/swagger.json";
                options.SwaggerEndpoint(url, "GeolettApi.Web v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            UpdateDatabase(app);

            hostApplicationLifetime.ApplicationStopped.Register(Log.CloseAndFlush);
        }

        private void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<GeolettContext>();

            context.Database.Migrate();
        }
    }
}
