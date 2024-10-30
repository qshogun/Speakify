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
        try
        {
            var result = await _timeEntryService.GetTimeEntry(timeEntryId);

            return Ok(result);
        }

        catch (ApplicationException)
        {
            return NotFound("TimeEntry with the given ID was not found");
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<List<TimeEntryResponse>>> CreateTimeEntry(TimeEntryCreateRequest timeEntryCreateRequest)
    {
        return Ok(await _timeEntryService.CreateTimeEntry(timeEntryCreateRequest));
    }

    [HttpPut("{timeEntryId}")]
    public async Task<ActionResult<TimeEntryResponse>> UpdateTimeEntry(Guid timeEntryId, TimeEntryUpdateRequest timeEntryUpdateRequest)
    {
        try
        {
            var result = await _timeEntryService.UpdateTimeEntry(timeEntryId, timeEntryUpdateRequest);
            return Ok(result);
        }

        catch (ApplicationException)
        {
            return NotFound("TimeEntry with the given ID was not found");
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{timeEntryId}")]
    public async Task<ActionResult<TimeEntryResponse>> DeleteTimeEntry(Guid timeEntryId)
    {
        try
        {
            var result = await _timeEntryService.DeleteTimeEntry(timeEntryId);
            return Ok(result);
        }

        catch (ApplicationException)
        {
            return NotFound("TimeEntry with the given ID was not found");
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<ActionResult<List<TimeEntryResponse>>> DeleteAllTimeEntries()
    {
        return Ok(await _timeEntryService.DeleteAllTimeEntries());
    }
}
