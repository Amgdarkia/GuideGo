namespace GuideGoAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using GuideGoAPI.Entities;
    public class GuideContext : DbContext
    {
        public GuideContext(DbContextOptions<GuideContext> options) : base(options)
        {
        }
        public DbSet<Guide> Guides { get; set; } 
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Route> Routes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Guide Configuration
            modelBuilder.Entity<Guide>()
            .ToTable("Guides")
            .HasKey(g => g.GuideId);

            modelBuilder.Entity<Guide>()
           .Property(g => g.AverageRating)
           .HasPrecision(3,1);

            modelBuilder.Entity<Guide>()
            .Property(g => g.Languages)
            .HasColumnType("VARCHAR(MAX)");

            // Tourist Configuration
            modelBuilder.Entity<Tourist>()
                .Property(t => t.PhoneNumber)
                .HasMaxLength(15);

            modelBuilder.Entity<Tourist>()
                .Property(t => t.Email)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<Tourist>()
                .Property(t => t.Password)
                .HasMaxLength(100)
                .IsRequired();

            //Review Configuration
            modelBuilder.Entity<Review>()
                .ToTable("Reviews")
                .HasKey(r => r.ReviewId);
            modelBuilder.Entity<Review>()
                .Property(r => r.Rating)
                .HasPrecision (3,1);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Guide)
                .WithMany()
                .HasForeignKey(r => r.GuideId);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Tourist)
                .WithMany()
                .HasForeignKey(r => r.TouristId);
        }
    }
}
