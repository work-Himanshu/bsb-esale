using BSBESales.DTOs.Search;
using BSBESales.Services.StandardSearchService;
using Microsoft.AspNetCore.Mvc;

namespace BSBESales.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StandardSearchController : ControllerBase
{
    private readonly IStandardSearchService _service;

    public StandardSearchController(IStandardSearchService service)
    {
        _service = service;
    }
    
    [HttpGet("SearchStandards")]
    public async Task<IActionResult> GetByDisplayStdNo(
        [FromQuery] SearchStandardsRequestDto request)
    {
        if (request == null)
            throw new ArgumentException("Request is required");

        return Ok(await _service.SearchingStandards(request));
    }
}