
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance.Configurations;

public class DicomEntryConfiguration : IEntityTypeConfiguration<DicomEntry>
{
    public void Configure(EntityTypeBuilder<DicomEntry> builder)
    {
        builder.Property(entry => entry.DicomEntryId).HasColumnName("DicomEntryID");

        builder.Property(entry => entry.Published).HasDefaultValue(true);

        builder.HasOne(entry => entry.Patient)
            .WithOne(patient => patient.DicomEntry)
            .HasForeignKey<DicomEntry>(entry => entry.PatientId);

        builder.HasOne(entry => entry.ArchiveFile)
            .WithOne(archive => archive.DicomEntry)
            .HasForeignKey<DicomEntry>(entry => entry.ArchiveFileId);
    }
}
