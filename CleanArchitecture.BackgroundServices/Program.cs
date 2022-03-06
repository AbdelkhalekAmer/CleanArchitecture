using CleanArchitecture.Application;
using CleanArchitecture.Application.DicomEntries.Commands.CreateDicomEntry;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Persistance;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.BackgroundServices;

public class Program
{
    public static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.local.json", true, true)
                .AddEnvironmentVariables()
                .Build();
        services.AddInfrastructure();
        services.AddPersistence(configuration);
        services.AddApplication();

        var sp = services.BuildServiceProvider();
        //services.AddHealthChecks().AddDbContextCheck<DicomDbContext>();

        var mediator = sp.GetService<IMediator>();
        if (mediator is not null) await mediator.Send(
            new CreateDicomEntryFromArchiveFileCommand("C:/Users/abdelkhalek.amer/Desktop/400418.2.18.iso",
            $"C:/Users/abdelkhalek.amer/Desktop/Extracted/{Guid.NewGuid()}"));

    }
}