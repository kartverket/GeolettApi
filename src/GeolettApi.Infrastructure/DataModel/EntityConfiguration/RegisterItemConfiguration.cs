using GeolettApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeolettApi.Infrastructure.DataModel.EntityConfiguration
{
    internal static class RegisterItemConfiguration
    {
        internal static void Configure(EntityTypeBuilder<RegisterItem> builder)
        {
            builder
                .ToTable("RegisterItems")
                .HasKey(registerItem => registerItem.Id);

            builder
                .Property(registerItem => registerItem.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(registerItem => registerItem.Title)
                .IsRequired();

            builder
                .HasOne(registerItem => registerItem.DataSet)
                .WithOne()
                .HasForeignKey<RegisterItem>(registerItem => registerItem.DataSetId);

            builder
                .HasOne(registerItem => registerItem.Reference)
                .WithOne()
                .HasForeignKey<RegisterItem>(registerItem => registerItem.ReferenceId);

            builder
                .HasMany(registerItem => registerItem.Links)
                .WithOne()
                .HasForeignKey(registerItemLink => registerItemLink.RegisterItemId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
