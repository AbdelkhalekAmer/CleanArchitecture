
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance.Configurations;

public class InstanceConfiguration : IEntityTypeConfiguration<Instance>
{
    public void Configure(EntityTypeBuilder<Instance> builder)
    {
        builder.Property(instance => instance.InstanceId).HasColumnName("InstanceID");

        builder.HasOne(instance => instance.File)
            .WithOne(file => file.Instance)
            .HasForeignKey<Instance>(instance => instance.FileId);
    }
}
