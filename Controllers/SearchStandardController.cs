using BSBESales.DTOs.Search;
using BSBESales.Services.AutoSearchService;
using Microsoft.AspNetCore.Mvc;

namespace BSBESales.Controllers;

[ApiController]
[Route("api/search/standards")]
public class SearchStandardController : ControllerBase
{
    private readonly IAutoSearchServices _service;

    public SearchStandardController(IAutoSearchServices service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] SearchStandardRequestDto request)
    {
        var result = await _service.SearchAsync(request);
        return Ok(result);
    }
}