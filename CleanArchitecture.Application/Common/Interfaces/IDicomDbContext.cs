using Microsoft.EntityFrameworkCore;

using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IDicomDbContext
{
    public DbSet<Domain.Entities.File> Files { get; set; }
    public DbSet<ArchiveFile> ArchiveFiles { get; set; }
    public DbSet<DicomEntry> DicomEntries { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Study> Studies { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<Instance> Instances { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
