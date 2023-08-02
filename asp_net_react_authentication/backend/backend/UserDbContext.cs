using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {}

        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //get?
            modelBuilder.Entity<AppUser>().ToTable("Users");
        }
    }
}
