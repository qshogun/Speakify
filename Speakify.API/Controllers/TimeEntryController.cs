using Microsoft.AspNetCore.Mvc;

namespace Speakify.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TimeEntryController(ITimeEntryService timeEntryService) : ControllerBase
{
    private readonly ITimeEntryService _timeEntryService = timeEntryService;

    [HttpGet]
    public async Task<ActionResult<List<TimeEntryResponse>>> GetAllTimeEntries()
    {
        return Ok(await _timeEntryService.GetAllTimeEntries());
    }

    [HttpGet("{timeEntryId}")]
    public async Task<ActionResult<TimeEntryResponse>> GetTimeEntry(Guid timeEntryId)
    {
        var result = await _timeEntryService.GetTimeEntry(timeEntryId);
        return result is null ? NotFound("TimeEntry with the given ID was not found") : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<List<TimeEntryResponse>>> CreateTimeEntry(TimeEntryCreateRequest timeEntryCreateRequest)
    {
        return Ok(await _timeEntryService.CreateTimeEntry(timeEntryCreateRequest));
    }

    [HttpPut("{timeEntryId}")]
    public async Task<ActionResult<TimeEntryResponse>> UpdateTimeEntry(Guid timeEntryId, TimeEntryUpdateRequest timeEntryUpdateRequest)
    {
        var result = await _timeEntryService.UpdateTimeEntry(timeEntryId, timeEntryUpdateRequest);
        return result is null ? NotFound("TimeEntry with the given ID was not found") : Ok(result);
    }

    [HttpDelete("{timeEntryId}")]
    public async Task<ActionResult<TimeEntryResponse>> DeleteTimeEntry(Guid timeEntryId)
    {
        var result = await _timeEntryService.DeleteTimeEntry(timeEntryId);
        return result is null ? NotFound("TimeEntry with the given ID was not found") : Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult<List<TimeEntryResponse>>> DeleteAllTimeEntries()
    {
        return Ok(await _timeEntryService.DeleteAllTimeEntries());
    }
}
