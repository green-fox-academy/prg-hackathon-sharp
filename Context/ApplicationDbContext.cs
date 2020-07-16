using Microsoft.EntityFrameworkCore;
using programmersGuide.Models;
using programmersGuide.Models.Entities;

namespace programmersGuide.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Quiz> Quiz { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
