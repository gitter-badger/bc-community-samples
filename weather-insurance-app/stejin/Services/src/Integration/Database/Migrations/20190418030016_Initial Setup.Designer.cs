﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherInsurance.Integration.Database;

namespace WeatherInsurance.Integration.Database.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190418030016_Initial Setup")]
    partial class InitialSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherInsurance.Integration.Database.Model.ContractFile", b =>
                {
                    b.Property<long>("ContractFileId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApiVersion")
                        .HasMaxLength(25);

                    b.Property<string>("ContractFileName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ContractType")
                        .HasMaxLength(25);

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<bool>("IncludesJson");

                    b.Property<bool>("IncludesSol");

                    b.Property<string>("OwnerAddress")
                        .IsRequired()
                        .HasMaxLength(42);

                    b.HasKey("ContractFileId");

                    b.HasIndex("ContractFileName", "OwnerAddress")
                        .IsUnique();

                    b.ToTable("ContractFiles");
                });

            modelBuilder.Entity("WeatherInsurance.Integration.Database.Model.DeployedContract", b =>
                {
                    b.Property<string>("ContractAddress")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(42);

                    b.Property<string>("ConstructorArguments");

                    b.Property<long>("ContractFileId");

                    b.Property<string>("ContractName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("ContractType");

                    b.Property<DateTime>("ExpirationDateTime");

                    b.Property<long>("NetworkId");

                    b.Property<string>("OwnerAddress")
                        .IsRequired()
                        .HasMaxLength(42);

                    b.HasKey("ContractAddress");

                    b.HasIndex("ContractFileId");

                    b.HasIndex("ContractName")
                        .IsUnique();

                    b.HasIndex("NetworkId");

                    b.HasIndex("OwnerAddress");

                    b.ToTable("DeployedContracts");
                });

            modelBuilder.Entity("WeatherInsurance.Integration.Database.Model.Network", b =>
                {
                    b.Property<long>("NetworkId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NetworkName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("Platform");

                    b.Property<string>("ReferenceContractAddress")
                        .IsRequired()
                        .HasMaxLength(42);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("NetworkId");

                    b.HasIndex("NetworkName")
                        .IsUnique();

                    b.ToTable("Networks");
                });

            modelBuilder.Entity("WeatherInsurance.Integration.Database.Model.DeployedContract", b =>
                {
                    b.HasOne("WeatherInsurance.Integration.Database.Model.ContractFile", "ContractFile")
                        .WithMany()
                        .HasForeignKey("ContractFileId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WeatherInsurance.Integration.Database.Model.Network", "Network")
                        .WithMany()
                        .HasForeignKey("NetworkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
