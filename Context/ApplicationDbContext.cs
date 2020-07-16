using Microsoft.EntityFrameworkCore;
using programmersGuide.Models;
using programmersGuide.Models.Entities;

namespace programmersGuide.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> QuizResults { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
