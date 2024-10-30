namespace Speakify.API.Services;

public interface ITimeEntryService
{
    Task<List<TimeEntryResponse>> GetAllTimeEntries();
    Task<TimeEntryResponse> GetTimeEntry(Guid id);
    Task<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreateRequest timeEntryCreateRequest);
    Task<List<TimeEntryResponse>> DeleteAllTimeEntries();
    Task<List<TimeEntryResponse>> DeleteTimeEntry(Guid id);
    Task<TimeEntryResponse> UpdateTimeEntry(Guid id, TimeEntryUpdateRequest timeEntryUpdateRequest);
}
