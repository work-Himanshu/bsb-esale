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
    
    [HttpGet("Id")]
    public async Task<IActionResult> GetById(
        [FromQuery] string Id)
    {
        if (string.IsNullOrWhiteSpace(Id))
            throw new ArgumentException("StandardId is required");

        return Ok(await _standardService.GetStandardList(int.Parse(Id)));
    }
}