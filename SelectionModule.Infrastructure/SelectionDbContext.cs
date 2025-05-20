using Microsoft.EntityFrameworkCore;
using SelectionModule.Domain.Entites;

namespace SelectionModule.Infrastructure;

public class SelectionDbContext(DbContextOptions<SelectionDbContext> options) : DbContext(options)
{
    private DbSet<CandidateEntity> Candidates { get; set; }
    private DbSet<Position> Positions { get; set; }
    private DbSet<SelectionEntity> Selections { get; set; }
    private DbSet<Vacancy> Vacancies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vacancy>()
            .HasOne(x => x.Position);

        modelBuilder.Entity<CandidateEntity>()
            .HasOne(c => c.Selection)
            .WithOne(s => s.Candidate)
            .HasForeignKey<SelectionEntity>(s => s.CandidateId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<VacancyResponse>()
            .HasOne(vr => vr.Candidate)
            .WithMany(c => c.Responses)
            .HasForeignKey(vr => vr.CandidateId);

        modelBuilder.Entity<VacancyResponse>()
            .HasOne(vr => vr.Vacancy)
            .WithMany(v => v.Responses)
            .HasForeignKey(vr => vr.VacancyId);
    }
}