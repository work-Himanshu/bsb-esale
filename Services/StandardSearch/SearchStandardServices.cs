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
        // 1. Normalize Input
        var keyword = request.Keyword?.Trim().ToLower();
        keyword = keyword is null
            ? null
            : Regex.Replace(keyword, @"[^\w\s]", "");

        // 2. Split Keywords
        var words = keyword?
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            ?? Array.Empty<string>();

        // 3. Base Query
        var query = _context.SearchStandards.AsQueryable();

        // 4. Apply Filters
        if (request.SdoId.HasValue)
            query = query.Where(s => s.SdoId == request.SdoId.Value);

        if (request.StatusId.HasValue)
            query = query.Where(s => s.StatusId == request.StatusId.Value);

        // 5. Search Across Columns (AND + OR logic)
        foreach (var word in words)
        {
            query = query.Where(s =>
                s.StandardNo!.ToLower().Contains(word) ||
                s.Title!.ToLower().Contains(word) ||
                (s.StdKeyword != null && s.StdKeyword.ToLower().Contains(word)) ||
                s.SearchQuery!.ToLower().Contains(word)
            );
        }

        // 6. Pagination
        var totalRecords = await query.CountAsync();

        var data = await query
            .OrderBy(s => s.StandardNo)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(s => new SearchStandardResponseDto
            {
                Id = s.Id,
                StandardNo = s.StandardNo,
                Title = s.Title,
                Description = s.StdKeyword,
                SdoId = s.SdoId
            })
            .ToListAsync();

        // 7. Return Results
        return new PagedResponseDto<SearchStandardResponseDto>
        {
            Page = request.Page,
            PageSize = request.PageSize,
            TotalRecords = totalRecords,
            Data = data
        };
    }
}
