using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xuyang.CabBookingShop.Core.Entities;

namespace xuyang.CabBookingShop.Infrastructure.Data
{
    public class CabBookingShopDbContext: DbContext
    {
        public CabBookingShopDbContext(DbContextOptions<CabBookingShopDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>(ConfigurePlaces);
            modelBuilder.Entity<CabType>(ConfigureCabTypes);
            modelBuilder.Entity<BookingHistory>(ConfigureBookingHistory);
            modelBuilder.Entity<Booking>(ConfigureBooking);
        }

        private void ConfigurePlaces(EntityTypeBuilder<Place> builder)
        {
            builder.ToTable("Place");
            builder.Property(t => t.PlaceName).HasMaxLength(30);
        }

        private void ConfigureCabTypes(EntityTypeBuilder<CabType> builder)
        {
            builder.ToTable("CabType");
            builder.Property(t => t.CabTypeName).HasMaxLength(30);
        }

        private void ConfigureBookingHistory(EntityTypeBuilder<BookingHistory> builder)
        {
            builder.ToTable("BookingHistory");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Email).HasMaxLength(50);
            builder.Property(t => t.BookingDate).HasColumnType("date");
            builder.Property(t => t.BookingTime).HasMaxLength(5);
            builder.Property(t => t.PickUpAddress).HasMaxLength(200);
            builder.Property(t => t.Landmark).HasMaxLength(30);
            builder.Property(t => t.PickupDate).HasColumnType("date");
            builder.Property(t => t.PickupTime).HasMaxLength(5);
            builder.Property(t => t.ContactNo).HasMaxLength(25);
            builder.Property(t => t.Status).HasMaxLength(30);
            builder.Property(t => t.CompTime).HasMaxLength(5);
            builder.Property(t => t.Charge).HasColumnType("money");
            builder.Property(t => t.Feedback).HasMaxLength(1000);
            // foreign key constraints
            builder.HasOne(t => t.FromPlace).WithMany(t => t.FromBookingHistories).HasForeignKey(t => t.FromPlaceId);
            builder.HasOne(t => t.ToPlace).WithMany(t => t.ToBookingHistories).HasForeignKey(t => t.ToPlaceId);
        }

        private void ConfigureBooking(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Email).HasMaxLength(50);
            builder.Property(t => t.BookingDate).HasColumnType("date");
            builder.Property(t => t.BookingTime).HasMaxLength(5);
            builder.Property(t => t.PickUpAddress).HasMaxLength(200);
            builder.Property(t => t.Landmark).HasMaxLength(30);
            builder.Property(t => t.PickupDate).HasColumnType("date");
            builder.Property(t => t.PickupTime).HasMaxLength(5);
            builder.Property(t => t.ContactNo).HasMaxLength(25);
            builder.Property(t => t.Status).HasMaxLength(30);
            // foreign key constraints
            builder.HasOne(t => t.FromPlace).WithMany(t => t.FromBookings).HasForeignKey(t => t.FromPlaceId);
            builder.HasOne(t => t.ToPlace).WithMany(t => t.ToBookings).HasForeignKey(t => t.ToPlaceId);
        }

        public DbSet<Place> Places { get; set; }
        public DbSet<CabType> CabTypes { get; set; }
        public DbSet<BookingHistory> BookingHistories { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
