using BSBESales.DTOs.Standards;

namespace BSBESales.Services.StandardDetails;

public interface IStandardDetailsService
{
    Task<List<StandardDetailsResponse>> GetStandardDetailsandPrice(string StandardId);
}