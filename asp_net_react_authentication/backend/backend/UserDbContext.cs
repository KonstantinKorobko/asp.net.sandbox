using backend.Models;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {}

        public DbSet<AppUser> Users { get; set; }
        public DbSet<IdByUserName> IdsUsers { get; set; }
        public DbSet<IdByEmail> IdsEmails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().ToTable("users");

            modelBuilder.Entity<IdByUserName>().ToTable("ids_users");

            modelBuilder.Entity<IdByEmail>().ToTable("ids_emails");
        }
    }
}
