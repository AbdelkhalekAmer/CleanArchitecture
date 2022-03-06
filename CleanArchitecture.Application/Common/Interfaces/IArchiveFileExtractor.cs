namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IArchiveFileExtractor
    {
        Task ExtractAsync(string source, string destination);
    }
}
