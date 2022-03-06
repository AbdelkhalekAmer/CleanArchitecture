
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance.Configurations;

public class ArchiveFileConfiguration : IEntityTypeConfiguration<ArchiveFile>
{
    public void Configure(EntityTypeBuilder<ArchiveFile> builder)
    {
        builder.Property(file => file.ArchiveFileId).HasColumnName("ArchiveFileID");
    }
}
