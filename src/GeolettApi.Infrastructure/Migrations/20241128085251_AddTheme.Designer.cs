﻿// <auto-generated />
using System;
using GeolettApi.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeolettApi.Infrastructure.Migrations
{
    [DbContext(typeof(GeolettContext))]
    [Migration("20241128085251_AddTheme")]
    partial class AddTheme
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GeolettApi.Domain.Models.DataSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BufferDistance")
                        .HasColumnType("int");

                    b.Property<string>("BufferPossibleMeasures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BufferText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Namespace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObjectTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlGmlSchema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlMetadata")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UuidMetadata")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ObjectTypeId")
                        .IsUnique();

                    b.ToTable("DataSets", "dbo");
                });

            modelBuilder.Entity("GeolettApi.Domain.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Links", "dbo");
                });

            modelBuilder.Entity("GeolettApi.Domain.Models.ObjectType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Attribute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ObjectTypes", "dbo");
                });

            modelBuilder.Entity("GeolettApi.Domain.Models.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OrgNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Organizations", "dbo");
                });

            modelBuilder.Entity("GeolettApi.Domain.Models.Reference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CircularFromMinistryId")
                        .HasColumnType("int");

                    b.Property<int?>("OtherLawId")
                        .HasColumnType("int");

                    b.Property<int?>("Tek17Id")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CircularFromMinistryId")
                        .IsUnique()
                        .HasFilter("[CircularFromMinistryId] IS NOT NULL");

                    b.HasIndex("OtherLawId")
                        .IsUnique()
                        .HasFilter("[OtherLawId] IS NOT NULL");

                    b.HasIndex("Tek17Id")
                        .IsUnique()
                        .HasFilter("[Tek17Id] IS NOT NULL");

                    b.ToTable("References", "dbo");
                });

            modelBuilder.Entity("GeolettApi.Domain.Models.RegisterItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ContextType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DataSetId")
                        .HasColumnType("int");

                    b.Property<string>("DegreeRisk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DialogText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guidance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("OtherComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("PossibleMeasures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReferenceId")
                        .HasColumnType("int");

                    b.Property<string>("Sign1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sign2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sign3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sign4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sign5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sign6")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TechnicalComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Theme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Uuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("Id");

                    b.HasIndex("DataSetId")
                        .IsUnique()
                        .HasFilter("[DataSetId] IS NOT NULL");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ReferenceId")
                        .IsUnique()
                        .HasFilter("[ReferenceId] IS NOT NULL");

                    b.ToTable("RegisterItems", "dbo");
                });

            modelBuilder.Entity("GeolettApi.Domain.Models.RegisterItemLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LinkId")
                        .HasColumnType("int");

                    b.Property<int>("RegisterItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LinkId");

                    b.HasIndex("RegisterItemId");

                    b.ToTable("RegisterItemLinks", "dbo");
                });

            modelBuilder.Entity("GeolettApi.Domain.Models.DataSet", b =>
                {
                    b.HasOne("GeolettApi.Domain.Models.ObjectType", "TypeReference")
                        .WithOne()
                        .HasForeignKey("GeolettApi.Domain.Models.DataSet", "ObjectTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeReference");
                });

            modelBuilder.Entity("GeolettApi.Domain.Models.Reference", b =>
                {
                    b.HasOne("GeolettApi.Domain.Models.Link", "CircularFromMinistry")
                        .WithOne()
                        .HasForeignKey("GeolettApi.Domain.Models.Reference", "CircularFromMinistryId");

                    b.HasOne("GeolettApi.Domain.Models.Link", "OtherLaw")
                        .WithOne()
                        .HasForeignKey("GeolettApi.Domain.Models.Reference", "OtherLawId");

                    b.HasOne("GeolettApi.Domain.Models.Link", "Tek17")
                        .WithOne()
                        .HasForeignKey("GeolettApi.Domain.Models.Reference", "Tek17Id");

                    b.Navigation("CircularFromMinistry");

                    b.Navigation("OtherLaw");

                    b.Navigation("Tek17");
                });

            modelBuilder.Entity("GeolettApi.Domain.Models.RegisterItem", b =>
                {
                    b.HasOne("GeolettApi.Domain.Models.DataSet", "DataSet")
                        .WithOne()
                        .HasForeignKey("GeolettApi.Domain.Models.RegisterItem", "DataSetId");

                    b.HasOne("GeolettApi.Domain.Models.Organization", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GeolettApi.Domain.Models.Reference", "Reference")
                        .WithOne()
                        .HasForeignKey("GeolettApi.Domain.Models.RegisterItem", "ReferenceId");

                    b.Navigation("DataSet");

                    b.Navigation("Owner");

                    b.Navigation("Reference");
                });

            modelBuilder.Entity("GeolettApi.Domain.Models.RegisterItemLink", b =>
                {
                    b.HasOne("GeolettApi.Domain.Models.Link", "Link")
                        .WithMany()
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GeolettApi.Domain.Models.RegisterItem", null)
                        .WithMany("Links")
                        .HasForeignKey("RegisterItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Link");
                });

            modelBuilder.Entity("GeolettApi.Domain.Models.RegisterItem", b =>
                {
                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
