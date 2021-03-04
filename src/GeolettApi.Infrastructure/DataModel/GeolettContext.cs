using GeolettApi.Domain.Models;
using GeolettApi.Infrastructure.DataModel.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace GeolettApi.Infrastructure.DataModel
{
    public class GeolettContext : DbContext
    {
        public GeolettContext()
        {
        }

        public GeolettContext(
            DbContextOptions<GeolettContext> options) : base(options)
        {
        }

        public DbSet<RegisterItem> RegisterItems { get; set; }
        public DbSet<DataSet> DataSets { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<ObjectType> ObjectTypes { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<RegisterItemLink> RegisterItemLinks { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");

            builder.Entity<RegisterItem>(RegisterItemConfiguration.Configure);
            builder.Entity<DataSet>(DataSetConfiguration.Configure);
            builder.Entity<Reference>(ReferenceConfiguration.Configure);
            builder.Entity<ObjectType>(ObjectTypeConfiguration.Configure);
            builder.Entity<RegisterItemLink>(RegisterItemLinkConfiguration.Configure);
            builder.Entity<Link>(LinkConfiguration.Configure);
            builder.Entity<Organization>(OrganizationConfiguration.Configure);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.LogTo(System.Console.WriteLine);
    }
}
