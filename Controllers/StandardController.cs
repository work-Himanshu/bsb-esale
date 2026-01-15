using Microsoft.AspNetCore.Mvc;
using BSBESales.Services.StandardsServices;

namespace BSBESales.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StandardController: ControllerBase
{
    private readonly IStandardServices _standardService;
    public StandardController(IStandardServices standardService)
    {
        _standardService = standardService;
    }
    
    [HttpGet("StandardId")]
    public async Task<IActionResult> GetByDisplayStdNo(
        [FromQuery] string StandardId)
    {
        if (string.IsNullOrWhiteSpace(StandardId))
            throw new ArgumentException("StandardId is required");

        return Ok(await _standardService.GetStandardList(StandardId));
    }
}