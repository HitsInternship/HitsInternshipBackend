using DeanModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeanModule.Infrastructure;

public class DeanModuleDbContext : DbContext
{
    public DbSet<DeanMember> DeanMembers { get; set; }
    public DbSet<Semester> Semesters { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<StreamSemester?> StreamSemesters { get; set; }
    
    public DeanModuleDbContext(DbContextOptions<DeanModuleDbContext> options) : base(options)
    {
    }
}