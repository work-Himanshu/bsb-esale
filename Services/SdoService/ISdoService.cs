using BSBESales.DTOs.Sdos;
using BSBESales.Models;

namespace BSBESales.Services.SdoService;

public interface ISdoService
{
    Task<List<sdosResponse>> GetSdoList();
}