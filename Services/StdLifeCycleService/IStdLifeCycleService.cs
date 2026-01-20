using BSBESales.DTOs.Standards;

namespace BSBESales.Services.StdLifeCycleService;

public interface IStdLifeCycleService
{
    Task <List<response_StandardDTOs>> GetStandardWithAllParents(int Id);
}