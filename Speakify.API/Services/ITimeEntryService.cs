using Speakify.Shared.Entities;
using Speakify.Shared.Models.TimeEntry;

namespace Speakify.API.Services;

public interface ITimeEntryService
{
    List<TimeEntryResponse> GetAllTimeEntries();
    TimeEntryResponse? GetTimeEntry(Guid id);
    List<TimeEntryResponse> CreateTimeEntry(TimeEntryCreateRequest timeEntryCreateRequest);
    List<TimeEntryResponse> DeleteAllTimeEntries();
    List<TimeEntryResponse>? DeleteTimeEntry(Guid id);
    TimeEntryResponse? UpdateTimeEntry(Guid id, TimeEntryUpdateRequest timeEntryUpdateRequest);
}
