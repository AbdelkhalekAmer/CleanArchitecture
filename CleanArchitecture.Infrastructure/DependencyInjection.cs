
using Microsoft.Extensions.DependencyInjection;

using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IDateTime, MachineDateTime>();
        services.AddTransient<IArchiveFileExtractor, SevenZipTool>();
        services.AddTransient<IDicomReader<DicomEntry>, DicomReader>();

        return services;
    }
}