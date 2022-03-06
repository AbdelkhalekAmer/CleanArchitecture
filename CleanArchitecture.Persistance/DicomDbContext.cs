
using Microsoft.EntityFrameworkCore;

using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Common;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance
{
    public class DicomDbContext : DbContext, IDicomDbContext
    {
        private readonly IDateTime _dateTime;
        public DicomDbContext(DbContextOptions<DicomDbContext> options)
            : base(options)
        {
        }

        public DicomDbContext(DbContextOptions<DicomDbContext> options,
            IDateTime dateTime)
            : base(options)
        {
            _dateTime = dateTime;
        }

        public DbSet<Domain.Entities.File> Files { get; set; }
        public DbSet<ArchiveFile> ArchiveFiles { get; set; }
        public DbSet<DicomEntry> DicomEntries { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Study> Studies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Instance> Instances { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = Environment.MachineName;
                        entry.Entity.Created = _dateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = Environment.MachineName;
                        entry.Entity.LastModified = _dateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DicomDbContext).Assembly);
        }
    }
}
