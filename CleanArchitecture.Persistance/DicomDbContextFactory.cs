
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistance;

public class DicomDbContextFactory : DesignTimeDbContextFactoryBase<DicomDbContext>
{
    protected override DicomDbContext CreateNewInstance(DbContextOptions<DicomDbContext> options)
    {
        return new DicomDbContext(options);
    }
}
