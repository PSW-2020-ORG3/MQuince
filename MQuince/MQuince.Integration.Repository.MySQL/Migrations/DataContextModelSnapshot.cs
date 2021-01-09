﻿// <auto-generated />
using System;
using MQuince.Integration.Repository.MySQL.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MQuince.Integration.Repository.MySQL.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MQuince.Integration.Repository.MySQL.PersistenceEntities.ActionAndBenefitsPersistance", b =>
                {
                    b.Property<Guid>("ActionKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ActionName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("NewCost")
                        .HasColumnType("double");

                    b.Property<double>("OldCost")
                        .HasColumnType("double");

                    b.Property<string>("PharmacyName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ActionKey");

                    b.ToTable("ActionAndBenefits");
                });

            modelBuilder.Entity("MQuince.Integration.Repository.MySQL.PersistenceEntities.MedicationsConsumptionPersistance", b =>
                {
                    b.Property<Guid>("KeyConsumtion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateOfConsumtion")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("KeyConsumtion");

                    b.ToTable("MedicationsConsumption");
                });

            modelBuilder.Entity("MQuince.Integration.Repository.MySQL.PersistenceEntities.PharmacyPersistence", b =>
                {
                    b.Property<Guid>("ApiKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ApiKey");

                    b.ToTable("Pharmacy");
                });
#pragma warning restore 612, 618
        }
    }
}
