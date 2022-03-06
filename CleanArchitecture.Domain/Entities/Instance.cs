using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;

public class Instance: ExternalSourceEntity
{
    public int InstanceId { get; set; }
    public string? SOPInstanceUid { get; set; }
    public string? SOPClassUID { get; set; }

    public int SeriesId { get; set; }
    public Series? Series { get; set; }
    
    public int FileId { get; set; }
    public File? File { get; set; }
}
