namespace Speakify.Shared.Models.TimeEntry;
public class TimeEntryResponse
{
    public Guid Id { get; set; }
    public required string ProjectName { get; set; } = string.Empty;
    public DateTime StartUtc { get; set; } = DateTime.UtcNow;
    public DateTime? EndUtc { get; set; }
    public DateTime? UpdatedUtc { get; set; }
}
