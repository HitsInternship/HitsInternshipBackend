using Microsoft.EntityFrameworkCore;
using SelectionModule.Domain.Entites;

namespace SelectionModule.Infrastructure;

public class SelectionDbContext(DbContextOptions<SelectionDbContext> options) : DbContext(options)
{
    private DbSet<Candidate> Candidates { get; set; }
    private DbSet<Position> Positions { get; set; }
    private DbSet<Selection> Selections { get; set; }
    private DbSet<Vacancy> Vacancies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>()
            .HasOne(x => x.Selection)
            .WithOne(x => x.Candidate)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Vacancy>()
            .HasOne(x => x.Position);
    }
}