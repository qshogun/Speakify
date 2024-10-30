namespace Speakify.Shared.Entities;

public class TimeEntry : BaseEntity
{
    public required string ProjectName { get; set; }
    public DateTime StartUtc { get; set; } = DateTime.UtcNow;
    public DateTime? EndUtc { get; set; }

}
