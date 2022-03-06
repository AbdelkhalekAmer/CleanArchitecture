using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;

public class ArchiveFile : AuditableEntity
{
    public int ArchiveFileId { get; set; }
    public string? Name { get; set; }
    public string? FullName { get; set; }
    public string? Directory { get; set; }
    public string? Extension { get; set; }
    public string? ExtractedArchiveFullPath { get; set; }
    public DicomEntry? DicomEntry { get; set; }
}
