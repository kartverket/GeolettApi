using GeolettApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeolettApi.Infrastructure.DataModel.EntityConfiguration
{
    internal static class LinkConfiguration
    {
        internal static void Configure(EntityTypeBuilder<Link> builder)
        {
            builder
                .ToTable("Links")
                .HasKey(link => link.Id);

            builder
                .Property(link => link.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(link => link.Text)
                .IsRequired();

            builder
                .Property(link => link.Url)
                .IsRequired();

            builder
                .Ignore(link => link.ValidationResult);
        }
    }
}
