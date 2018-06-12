﻿// <auto-generated />
using BookingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BookingSystem.Migrations
{
    [DbContext(typeof(BookingContext))]
    [Migration("20180612220745_init2")]
    partial class init2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("BookingSystem.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<int>("NumberConcessionPrice");

                    b.Property<int>("NumberFullPrice");

                    b.Property<int>("PerformanceId");

                    b.Property<bool>("StoreEmail");

                    b.Property<decimal>("TotalCost");

                    b.HasKey("Id");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("BookingSystem.Models.Performances", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("ShowId");

                    b.HasKey("Id");

                    b.ToTable("Performances");
                });

            modelBuilder.Entity("BookingSystem.Models.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookingId");

                    b.Property<string>("SeatNumber");

                    b.HasKey("Id");

                    b.ToTable("Seat");
                });

            modelBuilder.Entity("BookingSystem.Models.Shows", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ConcessionPrice");

                    b.Property<DateTime>("EndDate");

                    b.Property<decimal>("FullPrice");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Shows");
                });
#pragma warning restore 612, 618
        }
    }
}
