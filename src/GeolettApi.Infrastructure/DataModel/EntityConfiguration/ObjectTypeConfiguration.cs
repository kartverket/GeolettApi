using GeolettApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeolettApi.Infrastructure.DataModel.EntityConfiguration
{
    internal static class ObjectTypeConfiguration
    {
        internal static void Configure(EntityTypeBuilder<ObjectType> builder)
        {
            builder
                .ToTable("ObjectTypes")
                .HasKey(objectType => objectType.Id);

            builder
                .Property(objectType => objectType.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
