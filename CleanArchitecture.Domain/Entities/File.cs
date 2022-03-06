using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;

public class File : AuditableEntity
{
    public int FileId { get; set; }
    public string? Name { get; set; }
    public string? FullName { get; set; }
    public string? Directory { get; set; }
    public string? Extension { get; set; }

    public Instance? Instance { get; set; }
}
