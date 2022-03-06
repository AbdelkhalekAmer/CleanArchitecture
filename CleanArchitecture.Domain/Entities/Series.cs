using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities;

public class Series: ExternalSourceEntity
{
    public Series()
    {
        Instances = new HashSet<Instance>();
    }

    public int SeriesId { get; set; }
    public int Number { get; set; }
    public string? Modality { get; set; }
    public string? Description { get; set; }
    public DateTime? Date { get; set; }
    public TimeSpan? Time { get; set; }

    public int StudyId { get; set; }
    public Study? Study { get; set; }
    
    public ICollection<Instance> Instances { get; set; }
}
