using BSBESales.DTOs.Standards;

namespace BSBESales.Services.StandardsServices;

public interface IStandardServices
{
    Task<List<response_StandardDTOs>> GetStandardList(int Id);
}