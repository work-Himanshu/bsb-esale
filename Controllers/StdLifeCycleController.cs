using BSBESales.Services.StdLifeCycleService;
using Microsoft.AspNetCore.Mvc;

namespace BSBESales.Controllers;


[Route("api/[controller]")]
[ApiController]
public class StdLifeCycleController:ControllerBase
{
    private readonly IStdLifeCycleService _StdLifeCycleService;
    public StdLifeCycleController(IStdLifeCycleService StdLifeCycleService)
    {
        _StdLifeCycleService = StdLifeCycleService;
    }


    [HttpGet("Id")]
    public async Task<IActionResult> GetByID(
        [FromQuery] string Id)
    {
        if (string.IsNullOrWhiteSpace(Id))
            throw new ArgumentException("Id is required");

        return Ok(await _StdLifeCycleService.GetStandardWithAllParents(int.Parse(Id)));
    }
}