namespace Speakify.Shared.Entities;

public class TimeEntry : BaseEntity
{
    public required Project Project { get; set; } = new Project() { Name = string.Empty};
    public required DateTime StartUtc { get; set; } = DateTime.UtcNow;
    public DateTime? EndUtc { get; set; }
}
