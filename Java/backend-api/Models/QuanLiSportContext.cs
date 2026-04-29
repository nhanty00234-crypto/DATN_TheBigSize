using Microsoft.EntityFrameworkCore;

namespace BackendApi.Models
{
    public class QuanLiSportContext : DbContext
    {
        public QuanLiSportContext(DbContextOptions<QuanLiSportContext> options) : base(options)
        {
        }

        // DbSet cho các bảng
        public DbSet<Account> Accounts { get; set; }
        public DbSet<San> Sans { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình các bảng và quan hệ ở đây
            modelBuilder.Entity<Account>().HasKey(a => a.Id);
            modelBuilder.Entity<San>().HasKey(s => s.Id);
            modelBuilder.Entity<Booking>().HasKey(b => b.Id);

            // Quan hệ: Booking có AccountId và SanId
            modelBuilder.Entity<Booking>()
                .HasOne<Account>()
                .WithMany(a => a.Bookings)
                .HasForeignKey(b => b.AccountId);

            modelBuilder.Entity<Booking>()
                .HasOne<San>()
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.SanId);
        }
    }

    public class Booking
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int SanId { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } // Pending, Confirmed, Cancelled
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
