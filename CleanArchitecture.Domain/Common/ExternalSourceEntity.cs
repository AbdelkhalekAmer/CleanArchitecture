namespace CleanArchitecture.Domain.Common
{
    public class ExternalSourceEntity : AuditableEntity
    {
        public string? SourceName { get; set; }
        public string? SourceUid { get; set; }
    }
}
