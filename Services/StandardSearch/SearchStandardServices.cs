using BSBESales.Data;
using BSBESales.DTOs.Search;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BSBESales.Services.StandardSearch;

public class StandardSearchService : IStandardSearchService
{
    private readonly AppDbContext _context;

    public StandardSearchService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResponseDto<SearchStandardResponseDto>> SearchAsync(
        SearchStandardRequestDto request)
    {
        // 1. Normalize keyword
        var keyword = request.Keyword?.Trim().ToLower();
        if (string.IsNullOrWhiteSpace(keyword))
            return EmptyResponse(request);

        keyword = Regex.Replace(keyword, @"[^\w\s-]", " ");

        // 2. Tokenize (AND logic)
        var tokens = keyword
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Distinct()
            .ToArray();

        // 3. Base query
        var query = _context.SearchStandards.AsQueryable();

        // 4. Apply filters
        if (request.SdoId.HasValue)
            query = query.Where(x => x.SdoId == request.SdoId.Value);

        if (request.StatusId.HasValue)
            query = query.Where(x => x.StatusId == request.StatusId.Value);

        // 5. Token-based AND matching (case-insensitive by default in MySQL)
        foreach (var token in tokens)
        {
            var lowerToken = token.ToLower();
            query = query.Where(s =>
                s.StandardNo!.ToLower().Contains(lowerToken) ||
                s.Title!.ToLower().Contains(lowerToken) ||
                (s.StdKeyword != null && s.StdKeyword.ToLower().Contains(lowerToken)) ||
                s.SearchQuery!.ToLower().Contains(lowerToken)
            );
        }

        // 6. Count AFTER filtering, BEFORE paging
        var totalRecords = await query.CountAsync();

        // 7. Fetch filtered results into memory
        var allResults = await query
            .Select(s => new
            {
                s.Id,
                s.StandardNo,
                s.Title,
                s.StdKeyword,
                s.SdoId
            })
            .ToListAsync();

        // 8. Apply relevance ranking in memory (avoid SQL collation issues)
        var rankedResults = allResults
            .Select(s => new
            {
                Entity = s,
                Priority =
                    s.StandardNo!.Equals(keyword, StringComparison.OrdinalIgnoreCase) ? 0 :
                    s.StandardNo!.StartsWith(keyword, StringComparison.OrdinalIgnoreCase) ? 1 :
                    s.StandardNo!.Contains(keyword, StringComparison.OrdinalIgnoreCase) ? 2 :
                    s.Title!.StartsWith(keyword, StringComparison.OrdinalIgnoreCase) ? 3 :
                    s.Title!.Contains(keyword, StringComparison.OrdinalIgnoreCase) ? 4 :
                    5
            })
            .OrderBy(x => x.Priority)
            .ThenBy(x => x.Entity.StandardNo);

        // 9. Apply paging and map to DTO
        var data = rankedResults
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(x => new SearchStandardResponseDto
            {
                Id = x.Entity.Id,
                StandardNo = x.Entity.StandardNo,
                Title = x.Entity.Title,
                Description = x.Entity.StdKeyword,
                SdoId = x.Entity.SdoId
            })
            .ToList();

        // 10. Response
        return new PagedResponseDto<SearchStandardResponseDto>
        {
            Page = request.Page,
            PageSize = request.PageSize,
            TotalRecords = totalRecords,
            Data = data
        };
    }

    private static PagedResponseDto<SearchStandardResponseDto> EmptyResponse(
        SearchStandardRequestDto request)
    {
        return new PagedResponseDto<SearchStandardResponseDto>
        {
            Page = request.Page,
            PageSize = request.PageSize,
            TotalRecords = 0,
            Data = new List<SearchStandardResponseDto>()
        };
    }
}
