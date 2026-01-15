using BSBESales.DTOs.Search;

namespace BSBESales.Services.StandardSearch;

public interface IStandardSearchService
{
    Task<PagedResponseDto<SearchStandardResponseDto>> SearchAsync(
        SearchStandardRequestDto request);
}