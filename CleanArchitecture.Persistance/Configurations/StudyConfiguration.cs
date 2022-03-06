
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance.Configurations;

public class StudyConfiguration : IEntityTypeConfiguration<Study>
{
    public void Configure(EntityTypeBuilder<Study> builder)
    {
        builder.Property(study => study.StudyId).HasColumnName("StudyID");

        builder.HasMany(study => study.Series)
            .WithOne(series => series.Study)
            .HasForeignKey(series => series.StudyId);
    }
}
