﻿// <auto-generated />
using System;
using MQuince.Repository.SQL.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MQuince.Repository.SQL.Migrations
{
    [DbContext(typeof(MQuinceDbContext))]
    [Migration("20201103094943_DbInit")]
    partial class DbInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MQuince.Entities.Users.Adress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CityId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Adress");
                });

            modelBuilder.Entity("MQuince.Entities.Users.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PostNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("MQuince.Entities.Users.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Number")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.FeedbackPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Anonymous")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.UserPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("BirthPlaceId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ContactId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Jmbg")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("ResidenceId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("BirthPlaceId");

                    b.HasIndex("ContactId");

                    b.HasIndex("ResidenceId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.UserPersistence", b =>
                {
                    b.HasOne("MQuince.Entities.Users.City", "BirthPlace")
                        .WithMany()
                        .HasForeignKey("BirthPlaceId");

                    b.HasOne("MQuince.Entities.Users.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("MQuince.Entities.Users.Adress", "Residence")
                        .WithMany()
                        .HasForeignKey("ResidenceId");
                });
#pragma warning restore 612, 618
        }
    }
}
