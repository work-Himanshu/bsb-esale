using BSBESales.DTOs.Search;

namespace BSBESales.Services.StandardSearchService;

public interface IStandardSearchService
{
    Task<List<SearchStandardsResponseDto>> SearchingStandards(
        SearchStandardsRequestDto request);
}