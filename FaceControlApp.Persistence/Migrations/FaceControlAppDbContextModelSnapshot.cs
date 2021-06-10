﻿// <auto-generated />
using System;
using FaceControlApp.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FaceControlApp.Persistence.Migrations
{
    [DbContext(typeof(FaceControlAppDbContext))]
    partial class FaceControlAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FaceControlApp.Domain.Entities.BiometricalIdentifier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FaceImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BiometricalIdentifiers");
                });

            modelBuilder.Entity("FaceControlApp.Domain.Entities.Suspect", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FaceImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ShootingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Suspects");
                });
#pragma warning restore 612, 618
        }
    }
}
