﻿// <auto-generated />
using System;
using Almostengr.WeatherStation.Api.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Almostengr.WeatherStation.Api.Migrations
{
    [DbContext(typeof(StationDbContext))]
    [Migration("20220106003819_UpdateHumidityPressure")]
    partial class UpdateHumidityPressure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("Almostengr.WeatherStation.Api.Models.Observation", b =>
                {
                    b.Property<int>("ObservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<double?>("HumidityPct")
                        .HasColumnType("REAL");

                    b.Property<double?>("PressureMb")
                        .HasColumnType("REAL");

                    b.Property<double>("TemperatureC")
                        .HasColumnType("REAL");

                    b.HasKey("ObservationId");

                    b.ToTable("Observations");
                });
#pragma warning restore 612, 618
        }
    }
}
