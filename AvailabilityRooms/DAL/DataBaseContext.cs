using AvailabilityRooms.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace AvailabilityRooms.DAL
{
    public class DataBaseContext : DbContext
    {
       
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hotel>().HasIndex(c => c.Name).IsUnique(); 
            modelBuilder.Entity<Room>().HasIndex("Number", "HotelId").IsUnique(); 
        }

        public DbSet<Hotel> Hotels { get; set; } 
        public DbSet<Room> Rooms { get; set; }
       

    }
}
