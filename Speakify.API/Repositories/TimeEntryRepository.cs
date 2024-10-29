using Speakify.Shared.Entities;

namespace Speakify.API.Repositories;

public class TimeEntryRepository : ITimeEntryRepository
{
    private readonly DataContext _context;

    public TimeEntryRepository(DataContext context)
    {
        _context = context;
    }

    private static List<TimeEntry> _timeEntries = [];
    public async Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry)
    {
        _context.TimeEntries.Add(timeEntry);
        await _context.SaveChangesAsync();

        return await _context.TimeEntries.ToListAsync();
    }

    public List<TimeEntry> DeleteAllTimeEntries()
    {
        _timeEntries.Clear();
        return _timeEntries;
    }

    public List<TimeEntry>? DeleteTimeEntry(Guid id)
    {
        var timeEntry = _timeEntries.FirstOrDefault(te => te.Id == id);
        
        switch (timeEntry)
        {
            case null:
                return null;
            default:
                _timeEntries.Remove(timeEntry);
                return _timeEntries;
        }
    }

    public List<TimeEntry> GetAllTimeEntries() => _timeEntries;

    public TimeEntry? GetTimeEntry(Guid id) => _timeEntries.FirstOrDefault(timeEntry => timeEntry.Id == id);

    public TimeEntry? UpdateTimeEntry(Guid id, TimeEntry updatedTimeEntry)
    {
        if (!_timeEntries.Exists(te => te.Id == id)) return null;

        TimeEntry timeEntry = _timeEntries.First(te => te.Id == id);
        bool isUpdated = false;

        if (!timeEntry.ProjectName.Equals(updatedTimeEntry.ProjectName, StringComparison.InvariantCultureIgnoreCase))
        {
            if (!string.IsNullOrWhiteSpace(updatedTimeEntry.ProjectName))
            {
                timeEntry.ProjectName = updatedTimeEntry.ProjectName;
                isUpdated = true;
            }
        }

        if (updatedTimeEntry.EndUtc is not null &&
            (timeEntry.EndUtc is null || updatedTimeEntry.EndUtc.GetValueOrDefault().CompareTo(timeEntry.EndUtc.GetValueOrDefault()) > 0))
        {
            timeEntry.EndUtc = updatedTimeEntry.EndUtc;
            isUpdated = true;
        }

        if (updatedTimeEntry.StartUtc.CompareTo(timeEntry.StartUtc) > 0)
        {
            timeEntry.StartUtc = updatedTimeEntry.StartUtc;
            isUpdated = true;
        }

        if (isUpdated)
        {
            timeEntry.UpdatedUtc = DateTime.UtcNow;
        }

        return timeEntry;
    }

}
