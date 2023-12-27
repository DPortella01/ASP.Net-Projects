using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvcGames.Models;

namespace mvcGames.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUserProfile>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGame>().ToTable("VideoGame");
            modelBuilder.Entity<Platform>().ToTable("Platform");
        }

        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<FileModel> Files { get; set; }
    }
}