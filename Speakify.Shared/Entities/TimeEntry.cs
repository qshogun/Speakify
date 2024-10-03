namespace Speakify.Shared.Entities;

public class TimeEntry
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string ProjectName { get; set; }
    public DateTime StartUtc { get; set; } = DateTime.UtcNow;
    public DateTime? EndUtc { get; set; }
    public DateTime CreatedAtOtc { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedUtc { get; set; }
}

public record TimeEntryId(Guid Id)
{
}