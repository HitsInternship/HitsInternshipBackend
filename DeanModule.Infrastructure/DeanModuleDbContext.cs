using DeanModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeanModule.Infrastructure;

public class DeanModuleDbContext(DbContextOptions<DeanModuleDbContext> options) : DbContext(options)
{
    public DbSet<DeanMember> DeanMembers { get; set; }
    public DbSet<SemesterEntity> Semesters { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<StreamSemester> StreamSemesters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StreamSemester>()
            .HasOne(s => s.SemesterEntity);

        modelBuilder.Entity<Application>()
            .HasKey(a => a.Id);
    }
}