using Speakify.Shared.Entities;

namespace Speakify.API.Repositories;

public interface ITimeEntryRepository
{
    Task<List<TimeEntry>> GetAllTimeEntries();
    Task<TimeEntry?> GetTimeEntry(Guid id);
    Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry);
    Task<List<TimeEntry?>> DeleteTimeEntry(Guid id);
    Task<List<TimeEntry>> DeleteAllTimeEntries();
    Task<TimeEntry?> UpdateTimeEntry(Guid id, TimeEntry updatedTimeEntry);
}
