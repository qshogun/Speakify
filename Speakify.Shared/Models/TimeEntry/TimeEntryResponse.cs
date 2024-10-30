namespace Speakify.Shared.Models.TimeEntry;

public record struct TimeEntryResponse(Guid Id, DateTime? EndUtc, DateTime? UpdatedUtc)
{
    public required string ProjectName { get; set; } = string.Empty;
    public DateTime StartUtc { get; set; } = DateTime.UtcNow;
}
