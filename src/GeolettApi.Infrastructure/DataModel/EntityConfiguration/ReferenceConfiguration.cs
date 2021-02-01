using GeolettApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeolettApi.Infrastructure.DataModel.EntityConfiguration
{
    internal static class ReferenceConfiguration
    {
        internal static void Configure(EntityTypeBuilder<Reference> builder)
        {
            builder
                .ToTable("References")
                .HasKey(reference => reference.Id);

            builder
                .Property(reference => reference.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(reference => reference.Title)
                .IsRequired();

            builder
                .HasOne(reference => reference.Tek17)
                .WithOne()
                .HasForeignKey<Reference>(reference => reference.Tek17Id);

            builder
                .HasOne(reference => reference.OtherLaw)
                .WithOne()
                .HasForeignKey<Reference>(reference => reference.OtherLawId);

            builder
                .HasOne(reference => reference.CircularFromMinistry)
                .WithOne()
                .HasForeignKey<Reference>(reference => reference.CircularFromMinistryId);
        }
    }
}
