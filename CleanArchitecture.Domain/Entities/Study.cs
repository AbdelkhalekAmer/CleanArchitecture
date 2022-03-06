using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class Study: ExternalSourceEntity
    {
        public Study()
        {
            Series = new HashSet<Series>();
        }

        public int StudyId { get; set; }
        public int PatienId { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public Patient? Patient { get; set; }
        public ICollection<Series> Series { get; set; }
    }
}
