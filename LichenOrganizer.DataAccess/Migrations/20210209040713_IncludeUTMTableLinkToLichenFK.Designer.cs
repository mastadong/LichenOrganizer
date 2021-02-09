﻿// <auto-generated />
using System;
using LichenOrganizer.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LichenOrganizer.DataAccess.Migrations
{
    [DbContext(typeof(LichenOrganizerDbContext))]
    [Migration("20210209040713_IncludeUTMTableLinkToLichenFK")]
    partial class IncludeUTMTableLinkToLichenFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LichenOrganizer.Model.Friend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("LichenOrganizer.Model.Lichen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("AccessionNumber")
                        .HasColumnType("datetime2");

                    b.Property<string>("County")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Elevation")
                        .HasColumnType("int");

                    b.Property<string>("Genus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lichens");
                });

            modelBuilder.Entity("LichenOrganizer.Model.UTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("Eastings")
                        .HasColumnType("float");

                    b.Property<int>("LichenId")
                        .HasColumnType("int");

                    b.Property<double>("Northings")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("LichenId");

                    b.ToTable("UTMEntries");
                });

            modelBuilder.Entity("LichenOrganizer.Model.UTM", b =>
                {
                    b.HasOne("LichenOrganizer.Model.Lichen", "Lichen")
                        .WithMany()
                        .HasForeignKey("LichenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lichen");
                });
#pragma warning restore 612, 618
        }
    }
}