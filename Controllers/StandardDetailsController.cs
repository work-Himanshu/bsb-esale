// using Microsoft.AspNetCore.Mvc;
// namespace BSBESales.Controllers;
//
// public class StandardDetailsController
// {
//     
// }

using BSBESales.Services.StandardDetails;
using Microsoft.AspNetCore.Mvc;

namespace BSBESales.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StandardDetailsController: ControllerBase
{
    private readonly IStandardDetailsService _standardDetailsService;
    public StandardDetailsController(IStandardDetailsService standardDetailsService)
    {
        _standardDetailsService = standardDetailsService;
    }
    
    [HttpGet("StandardId")]
    public async Task<IActionResult> GetbyStandardID(
        [FromQuery] string StandardId)
    {
        if (string.IsNullOrWhiteSpace(StandardId))
            throw new ArgumentException("StandardId is required");

        return Ok(await _standardDetailsService.GetStandardDetailsandPrice(StandardId));
    }
}