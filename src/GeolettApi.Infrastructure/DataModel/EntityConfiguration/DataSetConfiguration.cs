using GeolettApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeolettApi.Infrastructure.DataModel.EntityConfiguration
{
    internal static class DataSetConfiguration
    {
        internal static void Configure(EntityTypeBuilder<DataSet> builder)
        {
            builder
                .ToTable("DataSets")
                .HasKey(dataSet => dataSet.Id);

            builder
                .Property(dataSet => dataSet.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(dataSet => dataSet.Title)
                .IsRequired();

            builder
                .HasOne(dataSet => dataSet.TypeReference)
                .WithOne()
                .HasForeignKey<ObjectType>(objectType => objectType.DataSetId);

            builder
                .Ignore(dataSet => dataSet.ValidationResult);
        }
    }
}
