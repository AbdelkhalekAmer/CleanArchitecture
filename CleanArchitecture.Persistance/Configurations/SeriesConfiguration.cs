
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance.Configurations;

public class SeriesConfiguration : IEntityTypeConfiguration<Series>
{
    public void Configure(EntityTypeBuilder<Series> builder)
    {
        builder.ToTable("Series");
        builder.Property(series => series.SeriesId).HasColumnName("SeriesID");

        builder.HasMany(series => series.Instances)
            .WithOne(instance => instance.Series)
            .HasForeignKey(instance => instance.SeriesId);
    }
}
