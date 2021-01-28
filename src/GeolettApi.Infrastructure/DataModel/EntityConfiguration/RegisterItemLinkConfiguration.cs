using GeolettApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeolettApi.Infrastructure.DataModel.EntityConfiguration
{
    internal static class RegisterItemLinkConfiguration
    {
        internal static void Configure(EntityTypeBuilder<RegisterItemLink> builder)
        {
            builder
                .ToTable("RegisterItemLinks")
                .HasKey(registerItemLink => registerItemLink.Id);

            builder
                .Property(registerItemLink => registerItemLink.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasOne(registerItemLink => registerItemLink.Link)
                .WithMany()
                .HasForeignKey(d => d.LinkId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
