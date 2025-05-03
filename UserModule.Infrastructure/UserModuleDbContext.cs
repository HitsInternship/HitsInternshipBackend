using Microsoft.EntityFrameworkCore;
using UserModule.Domain.Entities;

namespace UserModule.Infrastructure
{
    public class UserModuleDbContext : DbContext
    {
        public UserModuleDbContext(DbContextOptions<UserModuleDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasMany(User => User.Roles).WithMany(Role => Role.Users).UsingEntity("UserRole");
        }
    }
}
