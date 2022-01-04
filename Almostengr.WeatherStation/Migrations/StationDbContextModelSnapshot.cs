﻿// <auto-generated />
using System;
using Almostengr.WeatherStation.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Almostengr.WeatherStation.Migrations
{
    [DbContext(typeof(StationDbContext))]
    partial class StationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("Almostengr.WeatherStation.Models.Observation", b =>
                {
                    b.Property<int>("ObservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Humidity")
                        .HasColumnType("REAL");

                    b.Property<double?>("Pressure")
                        .HasColumnType("REAL");

                    b.Property<double?>("TemperatureC")
                        .IsRequired()
                        .HasColumnType("REAL");

                    b.HasKey("ObservationId");

                    b.ToTable("Observations");
                });
#pragma warning restore 612, 618
        }
    }
}
