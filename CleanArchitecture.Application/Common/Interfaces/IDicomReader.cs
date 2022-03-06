namespace CleanArchitecture.Application.Common.Interfaces;

public interface IDicomReader<T>
{
    Task<T> ReadFileAsync(string path, CancellationToken cancellationToken);
    Task<T> ReadDirectoryAsync(string path, CancellationToken cancellationToken);
}
