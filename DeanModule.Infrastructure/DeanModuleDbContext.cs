using DeanModule.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeanModule.Infrastructure;

public class DeanModuleDbContext : DbContext
{
    DbSet<DeanMember> DeanMembers { get; set; }
    DbSet<Semester> Semesters { get; set; }
    DbSet<Application> Applications { get; set; }
    DbSet<StreamSemester> StreamSemesters { get; set; }
    
    public DeanModuleDbContext(DbContextOptions<DeanModuleDbContext> options) : base(options)
    {
    }
}