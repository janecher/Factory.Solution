﻿// <auto-generated />
using Factory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Factory.Migrations
{
    [DbContext(typeof(FactoryContext))]
    [Migration("20200807214427_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Factory.Models.Engineer", b =>
                {
                    b.Property<int>("EngineerId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsActive");

                    b.Property<string>("LicenseName");

                    b.Property<int>("LocationId");

                    b.Property<string>("Name");

                    b.HasKey("EngineerId");

                    b.HasIndex("LocationId");

                    b.ToTable("Engineers");
                });

            modelBuilder.Entity("Factory.Models.EngineerMachine", b =>
                {
                    b.Property<int>("EngineerMachineId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EngineerId");

                    b.Property<int>("MachineId");

                    b.HasKey("EngineerMachineId");

                    b.HasIndex("EngineerId");

                    b.HasIndex("MachineId");

                    b.ToTable("EngineersMachines");
                });

            modelBuilder.Entity("Factory.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EngineerId");

                    b.Property<int>("MachineId");

                    b.Property<bool>("Status");

                    b.Property<string>("Type");

                    b.HasKey("IncidentId");

                    b.HasIndex("EngineerId");

                    b.HasIndex("MachineId");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("Factory.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Factory.Models.Machine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LocationId");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<string>("Status");

                    b.HasKey("MachineId");

                    b.HasIndex("LocationId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Factory.Models.Engineer", b =>
                {
                    b.HasOne("Factory.Models.Location", "Location")
                        .WithMany("Engineers")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Factory.Models.EngineerMachine", b =>
                {
                    b.HasOne("Factory.Models.Engineer", "Engineer")
                        .WithMany("Machines")
                        .HasForeignKey("EngineerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Factory.Models.Machine", "Machine")
                        .WithMany("Engineers")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Factory.Models.Incident", b =>
                {
                    b.HasOne("Factory.Models.Engineer", "Engineer")
                        .WithMany("Incidents")
                        .HasForeignKey("EngineerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Factory.Models.Machine", "Machine")
                        .WithMany("Incidents")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Factory.Models.Machine", b =>
                {
                    b.HasOne("Factory.Models.Location", "Location")
                        .WithMany("Machines")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
