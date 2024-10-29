using Microsoft.AspNetCore.Mvc;
using Speakify.API.Services;
using Speakify.Shared.Models.TimeEntry;

namespace Speakify.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TimeEntryController(ITimeEntryService timeEntryService) : ControllerBase
{
    private readonly ITimeEntryService _timeEntryService = timeEntryService;

    [HttpGet]
    public ActionResult<List<TimeEntryResponse>> GetAllTimeEntries()
    {
        return Ok(_timeEntryService.GetAllTimeEntries());
    }

    [HttpGet("{timeEntryId}")]
    public ActionResult<TimeEntryResponse> GetTimeEntry(Guid timeEntryId)
    {
        var result = _timeEntryService.GetTimeEntry(timeEntryId);
        return result is null ? NotFound("TimeEntry with the given ID was not found") : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<TimeEntryResponse>>> CreateTimeEntry(TimeEntryCreateRequest timeEntryCreateRequest)
    {
        return Ok(await _timeEntryService.CreateTimeEntry(timeEntryCreateRequest));
    }

    [HttpPut("{timeEntryId}")]
    public ActionResult<TimeEntryResponse> UpdateTimeEntry(Guid timeEntryId, TimeEntryUpdateRequest timeEntryUpdateRequest)
    {
        var result = _timeEntryService.UpdateTimeEntry(timeEntryId, timeEntryUpdateRequest);
        return result is null ? NotFound("TimeEntry with the given ID was not found") : Ok(result);
    }

    [HttpDelete("{timeEntryId}")]
    public ActionResult<TimeEntryResponse> DeleteTimeEntry(Guid timeEntryId)
    {
        var result = _timeEntryService.DeleteTimeEntry(timeEntryId);
        return result is null ? NotFound("TimeEntry with the given ID was not found") : Ok(result);
    }

    [HttpDelete]
    public ActionResult<List<TimeEntryResponse>> DeleteAllTimeEntries()
    {
        return Ok(_timeEntryService.DeleteAllTimeEntries());
    }
}
