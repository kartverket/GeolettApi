using System;
using System.IO;
using GeolettApi.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeolettApi.Web.Configuration
{
    public static class EntityFrameworkConfiguration
    {
        public static IServiceCollection AddEntityFrameworkForGeolett(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddDbContext<GeolettContext>(options =>
                options.UseSqlServer(configuration["EntityFramework:GeolettContext:ConnectionString"], builder =>
                    builder.MigrationsAssembly("GeolettApi.Infrastructure")));

            return services;
        }
    }

    internal class GeolettContextFactory : IDesignTimeDbContextFactory<GeolettContext>
    {
        public GeolettContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<GeolettContext>()
                .UseSqlServer(configuration["EntityFramework:GeolettContext:ConnectionString"], builder =>
                    builder.MigrationsAssembly("GeolettApi.Infrastructure"));

            return new GeolettContext(optionsBuilder.Options);
        }
    }
}
