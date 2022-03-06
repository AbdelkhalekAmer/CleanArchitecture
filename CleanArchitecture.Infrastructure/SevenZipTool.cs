using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Infrastructure;

public class SevenZipTool : IArchiveFileExtractor
{
    private readonly string _sevenZipToolExecutablePath;

    public SevenZipTool()
    {
        _sevenZipToolExecutablePath = Path.Combine(Directory.GetCurrentDirectory(), "7zip", "win-x64", "7z.exe");
    }

    public Task ExtractAsync(string source, string destination)
    {
        if (!Directory.Exists(destination)) Directory.CreateDirectory(destination);

        var args = $"x -y \"{source}\" -o\"{destination}\"";

        using var process = new RedirectedProcess(_sevenZipToolExecutablePath, args);

        if (process.Start())
        {
            process.WaitForExit();

            var error = process.Error;

            if (!string.IsNullOrWhiteSpace(error) && process.ExitCode != 0) throw new Exception(error);
        }

        return Task.CompletedTask;
    }
}