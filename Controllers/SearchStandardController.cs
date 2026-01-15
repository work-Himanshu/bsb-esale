using BSBESales.DTOs.Search;
using BSBESales.Services.StandardSearch;
using Microsoft.AspNetCore.Mvc;

namespace BSBESales.Controllers;

[ApiController]
[Route("api/search/standards")]
public class SearchStandardController : ControllerBase
{
    private readonly IStandardSearchService _service;

    public SearchStandardController(IStandardSearchService service)
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