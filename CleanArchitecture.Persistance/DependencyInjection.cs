
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DicomDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DicomDatabase")));

        services.AddScoped<IDicomDbContext>(provider => provider.GetService<DicomDbContext>());

        return services;
    }
}
