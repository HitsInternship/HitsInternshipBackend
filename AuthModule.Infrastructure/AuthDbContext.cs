using Microsoft.EntityFrameworkCore;
using System;
using AuthModule.Domain.Entity;

namespace AuthModel.Infrastructure

{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        public DbSet<AspNetUser> AspNetUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}