using DebrecenSpotter.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DebrecenSpotter.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users {get; set;}
        public DbSet<Sight> Sights {get; set;}
        public DbSet<Spotting> Spottings {get; set;}
        public DbSet<SightGallery> SightGalleries {get; set;}
        public DbSet<SightLike> SightLikes {get; set;}
        public DbSet<SpottingLike> SpottingLikes {get; set;}
        public DbSet<Visit> Visits {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Spotting>()
                        .HasOne(s => s.User)
                        .WithMany(u => u.Spottings)
                        .HasForeignKey(s => s.UserId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SightGallery>()
                        .HasOne(sg => sg.User)
                        .WithMany(u => u.SightPictures)
                        .HasForeignKey(sg => sg.UserId)
                        .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<SightGallery>()
                .HasOne(sg => sg.Sight)
                .WithMany(s => s.SightGalleries)
                .HasForeignKey(sg => sg.SightId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.LikedSights)
                .WithMany(s => s.LikedBy)
                .UsingEntity<SightLike>(
                    j => j.HasOne(sl => sl.Sight).WithMany(s => s.SightLikes).HasForeignKey(sl => sl.SightId),
                    j => j.HasOne(sl => sl.User).WithMany().HasForeignKey(sl => sl.UserId),
                    j => j.HasKey(sl => new { sl.UserId, sl.SightId })
                );

            modelBuilder.Entity<User>()
                .HasMany(u => u.VisitedSights)
                .WithMany(s => s.Visitors)
                .UsingEntity<Visit>(
                    j => j.HasOne(v => v.Sight).WithMany(s => s.Visits).HasForeignKey(v => v.SightId),
                    j => j.HasOne(v => v.User).WithMany().HasForeignKey(v => v.UserId),
                    j => j.HasKey(v => new { v.UserId, v.SightId }) 
                );
            modelBuilder.Entity<User>()
                .HasMany(u => u.LikedSpottings)
                .WithMany(s => s.UserLikes)
                .UsingEntity<SpottingLike>(
                    j => j.HasOne(sl => sl.Spotting).WithMany(s => s.SpottingLikes).HasForeignKey(sl => sl.SpottingId),
                    j => j.HasOne(sl => sl.User).WithMany().HasForeignKey(sl => sl.UserId),
                    j => j.HasKey(sl => new { sl.UserId, sl.SpottingId })
                );
        }
    }
}