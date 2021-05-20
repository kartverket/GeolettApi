using GeolettApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeolettApi.Infrastructure.DataModel.EntityConfiguration
{
    internal static class OrganizationConfiguration
    {
        internal static void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder
                .ToTable("Organizations")
                .HasKey(organization => organization.Id);

            builder
                .Property(organization => organization.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
