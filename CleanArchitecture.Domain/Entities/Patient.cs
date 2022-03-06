using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Enumerations;

namespace CleanArchitecture.Domain.Entities;

public class Patient: ExternalSourceEntity
{
    public Patient()
    {
        Studies = new HashSet<Study>();
    }

    public int PatientId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; } = Gender.None;
    public DicomEntry? DicomEntry { get; set; }
    public ICollection<Study> Studies { get; set; }
}