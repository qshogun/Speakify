namespace Speakify.Shared.Models.TimeEntry;

public record struct TimeEntryUpdateRequest(DateTime? StartUtc, DateTime? EndUtc)
{
    public string ProjectName { get; set; } = string.Empty;
}
