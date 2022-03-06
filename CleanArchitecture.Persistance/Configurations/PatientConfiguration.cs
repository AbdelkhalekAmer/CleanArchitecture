
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(patient => patient.PatientId).HasColumnName("PatientID");

        builder.HasMany(patient => patient.Studies)
            .WithOne(study => study.Patient)
            .HasForeignKey(study => study.PatienId);
    }
}
