using BSBESales.DTOs.Search;
using BSBESales.Services.AutoSearchService;
using Microsoft.AspNetCore.Mvc;

namespace BSBESales.Controllers;

[ApiController]
[Route("api/search/standards")]
public class AutoSearchController : ControllerBase
{
    private readonly IAutoSearchServices _service;

    public AutoSearchController(IAutoSearchServices service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] AutoSearchRequestDto request)
    {
        var result = await _service.SearchAsync(request);
        return Ok(result);
    }
}