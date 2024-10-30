using Mapster;

namespace Speakify.API.Services;

public class TimeEntryService(ITimeEntryRepository timeEntryRepository) : ITimeEntryService
{
    private readonly ITimeEntryRepository _timeEntryRepository = timeEntryRepository;

    public async Task<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreateRequest timeEntryCreateRequest)
    {
        TimeEntry timeEntry = timeEntryCreateRequest.Adapt<TimeEntry>();
        var result = await _timeEntryRepository.CreateTimeEntry(timeEntry);

        return result.Adapt<List<TimeEntryResponse>>();
    }

    public async Task<List<TimeEntryResponse>> DeleteAllTimeEntries()
    {
        var result = await _timeEntryRepository.DeleteAllTimeEntries();

        return result.Adapt<List<TimeEntryResponse>>();
    }

    public async Task<List<TimeEntryResponse>> DeleteTimeEntry(Guid id)
    {
        var result = await _timeEntryRepository.DeleteTimeEntry(id);

        return result.Adapt<List<TimeEntryResponse>>();
    }

    public async Task<List<TimeEntryResponse>> GetAllTimeEntries()
    {
        var result = await _timeEntryRepository.GetAllTimeEntries();

        return result.Adapt<List<TimeEntryResponse>>();
    }

    public async Task<TimeEntryResponse> GetTimeEntry(Guid id)
    {
        var result = await _timeEntryRepository.GetTimeEntry(id);

        return result.Adapt<TimeEntryResponse>();
    }

    public async Task<TimeEntryResponse> UpdateTimeEntry(Guid timeEntryId, TimeEntryUpdateRequest timeEntryUpdateRequest)
    {
        TimeEntry updatedTimeEntry = timeEntryUpdateRequest.Adapt<TimeEntry>();
        var result = await _timeEntryRepository.UpdateTimeEntry(timeEntryId, updatedTimeEntry);

        return result.Adapt<TimeEntryResponse>();
    }
}
