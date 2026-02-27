using Homework.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
             .HasMany(u => u.Tasks)
             .WithOne(t => t.User)
             .HasForeignKey(t => t.UserId);
        }
    }

}
