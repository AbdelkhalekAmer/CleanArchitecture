using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;

public class DicomEntry : AuditableEntity
{
    public int DicomEntryId { get; set; }
    public int? CaseNo { get; set; }
    public int? PartNo { get; set; }
    public bool Published { get; set; }

    public int? PatientId { get; set; }
    public Patient? Patient { get; set; }

    public int? ArchiveFileId { get; set; }
    public ArchiveFile? ArchiveFile { get; set; }
}