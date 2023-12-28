using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvcDriverWithAuth.Models;
using System.Diagnostics.Metrics;

namespace mvcDriverWithAuth.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Driver>().ToTable("Driver");
            modelBuilder.Entity<Make>().ToTable("Make");
        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Make> Makes { get; set; }

    }
}