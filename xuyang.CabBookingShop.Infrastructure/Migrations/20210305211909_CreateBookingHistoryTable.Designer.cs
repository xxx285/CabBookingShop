﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using xuyang.CabBookingShop.Infrastructure.Data;

namespace xuyang.CabBookingShop.Infrastructure.Migrations
{
    [DbContext(typeof(CabBookingShopDbContext))]
    [Migration("20210305211909_CreateBookingHistoryTable")]
    partial class CreateBookingHistoryTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("xuyang.CabBookingShop.Core.Entities.BookingHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BookingDate")
                        .HasColumnType("date");

                    b.Property<string>("BookingTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int?>("CabTypeId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Charge")
                        .HasColumnType("money");

                    b.Property<string>("CompTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("ContactNo")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Feedback")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("FromPlaceId")
                        .HasColumnType("int");

                    b.Property<string>("Landmark")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PickUpAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("PickupDate")
                        .HasColumnType("date");

                    b.Property<string>("PickupTime")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Status")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("ToPlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabTypeId");

                    b.HasIndex("FromPlaceId");

                    b.HasIndex("ToPlaceId");

                    b.ToTable("BookingHistory");
                });

            modelBuilder.Entity("xuyang.CabBookingShop.Core.Entities.CabType", b =>
                {
                    b.Property<int>("CabTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CabTypeName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CabTypeId");

                    b.ToTable("CabTypes");
                });

            modelBuilder.Entity("xuyang.CabBookingShop.Core.Entities.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PlaceName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PlaceId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("xuyang.CabBookingShop.Core.Entities.BookingHistory", b =>
                {
                    b.HasOne("xuyang.CabBookingShop.Core.Entities.CabType", "CabType")
                        .WithMany("BookingHistories")
                        .HasForeignKey("CabTypeId");

                    b.HasOne("xuyang.CabBookingShop.Core.Entities.Place", "FromPlace")
                        .WithMany("FromBookingHistories")
                        .HasForeignKey("FromPlaceId");

                    b.HasOne("xuyang.CabBookingShop.Core.Entities.Place", "ToPlace")
                        .WithMany("ToBookingHistories")
                        .HasForeignKey("ToPlaceId");

                    b.Navigation("CabType");

                    b.Navigation("FromPlace");

                    b.Navigation("ToPlace");
                });

            modelBuilder.Entity("xuyang.CabBookingShop.Core.Entities.CabType", b =>
                {
                    b.Navigation("BookingHistories");
                });

            modelBuilder.Entity("xuyang.CabBookingShop.Core.Entities.Place", b =>
                {
                    b.Navigation("FromBookingHistories");

                    b.Navigation("ToBookingHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
