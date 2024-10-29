using Mapster;
using Speakify.API.Repositories;
using Speakify.Shared.Entities;
using Speakify.Shared.Models.TimeEntry;

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

    public List<TimeEntryResponse> DeleteAllTimeEntries()
    {
        var result = _timeEntryRepository.DeleteAllTimeEntries();
        return result.Adapt<List<TimeEntryResponse>>();
    }

    public List<TimeEntryResponse>? DeleteTimeEntry(Guid id)
    {
        var result = _timeEntryRepository.DeleteTimeEntry(id);
        return result?.Adapt<List<TimeEntryResponse>>();
    }

    public List<TimeEntryResponse> GetAllTimeEntries()
    {
        var result = _timeEntryRepository.GetAllTimeEntries();
        return result.Adapt<List<TimeEntryResponse>>();
    }

    public TimeEntryResponse? GetTimeEntry(Guid id) =>
        _timeEntryRepository.GetTimeEntry(id)?.Adapt<TimeEntryResponse>();

    public TimeEntryResponse? UpdateTimeEntry(Guid timeEntryId, TimeEntryUpdateRequest timeEntryUpdateRequest)
    {
        TimeEntry updatedTimeEntry = timeEntryUpdateRequest.Adapt<TimeEntry>();
        var result = _timeEntryRepository.UpdateTimeEntry(timeEntryId, updatedTimeEntry);

        return result?.Adapt<TimeEntryResponse>();
    }
}
