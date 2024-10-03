namespace Speakify.Shared.Models.TimeEntry;
public class TimeEntryUpdateRequest
{
    public string ProjectName { get; set; } = string.Empty;
    public DateTime? StartUtc { get; set; }
    public DateTime? EndUtc { get; set; }
}
