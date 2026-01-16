using BSBESales.DTOs.Search;

namespace BSBESales.Services.AutoSearchService;

public interface IAutoSearchServices
{
    Task<PagedResponseDto<SearchStandardResponseDto>> SearchAsync(
        SearchStandardRequestDto request);
}