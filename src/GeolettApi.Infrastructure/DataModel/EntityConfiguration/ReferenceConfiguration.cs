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
                .WithMany()
                .HasForeignKey(reference => reference.Tek17Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(reference => reference.OtherLaw)
                .WithMany()
                .HasForeignKey(reference => reference.OtherLawId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(reference => reference.CircularFromMinistry)
                .WithMany()
                .HasForeignKey(reference => reference.CircularFromMinistryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Ignore(reference => reference.ValidationResult);
        }
    }
}
