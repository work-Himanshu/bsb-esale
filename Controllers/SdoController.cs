using Microsoft.AspNetCore.Mvc;
using BSBESales.DTOs.Sdos;
using BSBESales.Services.SdoService;

namespace BSBESales.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SdoController : Controller
{
    private readonly ISdoService _sdoService;

    public SdoController(ISdoService sdoService)
    {
        _sdoService = sdoService;
    }   

    [HttpGet]
    public async Task<ActionResult<List<sdosResponse>>> GetSdoList()
    {
        return Ok(await _sdoService.GetSdoList());
    }
}