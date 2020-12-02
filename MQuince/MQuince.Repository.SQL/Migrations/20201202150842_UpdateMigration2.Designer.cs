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
    [Migration("20201202150842_UpdateMigration2")]
    partial class UpdateMigration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Drug.AllergenPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Allergen");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.FeedbackPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Anonymous")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Approved")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Publish")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("User")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Users.DoctorPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Biography")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Jmbg")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("SpecializationId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Users.PatientPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ChosenDoctor")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Guest")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Jmbg")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ChosenDoctor");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Users.SpecializationPersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Users.WorkTimePersistence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("DoctorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EndTime")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("StartTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("WorkTime");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Users.DoctorPersistence", b =>
                {
                    b.HasOne("MQuince.Repository.SQL.PersistenceEntities.Users.SpecializationPersistence", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationId");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Users.PatientPersistence", b =>
                {
                    b.HasOne("MQuince.Repository.SQL.PersistenceEntities.Users.DoctorPersistence", "PersonalDoctor")
                        .WithMany()
                        .HasForeignKey("ChosenDoctor");
                });

            modelBuilder.Entity("MQuince.Repository.SQL.PersistenceEntities.Users.WorkTimePersistence", b =>
                {
                    b.HasOne("MQuince.Repository.SQL.PersistenceEntities.Users.DoctorPersistence", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");
                });
#pragma warning restore 612, 618
        }
    }
}
