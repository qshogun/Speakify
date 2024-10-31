namespace Speakify.API.Repositories;

public class TimeEntryRepository : ITimeEntryRepository
{
    private readonly DataContext _context;

    public TimeEntryRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry)
    {
        _context.TimeEntries.Add(timeEntry);
        await _context.SaveChangesAsync();

        return await _context.TimeEntries.ToListAsync();
    }

    public async Task<List<TimeEntry>> DeleteAllTimeEntries()
    {
        _context.TimeEntries.RemoveRange(_context.TimeEntries);
        await _context.SaveChangesAsync();

        return await _context.TimeEntries.ToListAsync() ;
    }

    public async Task<List<TimeEntry>> DeleteTimeEntry(Guid id)
    {
        var timeEntry = await _context.TimeEntries.FirstOrDefaultAsync(te => te.Id == id);
        
        switch (timeEntry)
        {
            case null:
                throw new ApplicationException($"Time entry with ID {id} could not be found");
            default:
                _context.TimeEntries.Remove(timeEntry);
                await _context.SaveChangesAsync();
                return await _context.TimeEntries.ToListAsync();
        }
    }

    public async Task<List<TimeEntry>> GetAllTimeEntries() => 
        await _context.TimeEntries.ToListAsync();

    public async Task<TimeEntry> GetTimeEntry(Guid id)
    {
        var result = await _context.TimeEntries.FirstOrDefaultAsync(timeEntry => timeEntry.Id == id);

        return result switch
        {
            null => throw new ApplicationException($"Time entry with ID {id} could not be found"),
            _ => result,
        };
    }

    public async Task<TimeEntry> UpdateTimeEntry(Guid id, TimeEntry updatedTimeEntry)
    {
        TimeEntry? timeEntry = await _context.TimeEntries.FirstOrDefaultAsync(te => te.Id == id)
            ?? throw new ApplicationException($"Time entry with ID {id} could not be found");

        bool isUpdated = false;

        if (!timeEntry.Project.Name.Equals(updatedTimeEntry.Project.Name, StringComparison.InvariantCultureIgnoreCase))
        {
            if (!string.IsNullOrWhiteSpace(updatedTimeEntry.Project.Name))
            {
                timeEntry.Project.Name = updatedTimeEntry.Project.Name;
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

        _context.TimeEntries.Update(timeEntry);
        await _context.SaveChangesAsync();

        return await _context.TimeEntries.FirstAsync(te => te.Id == timeEntry.Id);
    }
}
