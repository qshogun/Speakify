using Speakify.Shared.Entities;

namespace Speakify.API.Repositories;

public interface ITimeEntryRepository
{
    List<TimeEntry> GetAllTimeEntries();
    TimeEntry? GetTimeEntry(Guid id);
    List<TimeEntry> CreateTimeEntry(TimeEntry timeEntry);
    List<TimeEntry>? DeleteTimeEntry(Guid id);
    List<TimeEntry> DeleteAllTimeEntries();
    TimeEntry? UpdateTimeEntry(Guid id, TimeEntry updatedTimeEntry);
}
