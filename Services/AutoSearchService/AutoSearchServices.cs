using BSBESales.Data;
using BSBESales.DTOs.Search;
using BSBESales.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BSBESales.Services.AutoSearchService;

public class AutoSearchServices : IAutoSearchServices
{
    private readonly AppDbContext _context;

    public AutoSearchServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResponseDto<AutoSearchResponseDto>> SearchAsync(
        AutoSearchRequestDto request)
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

        // 7. Conditional left join with StdPrice if PriceOption == 1
        IQueryable<AutoSearchResponseDto> finalQuery;
        
        if (request.PriceOption == 1)
        {
            finalQuery = query
                .GroupJoin(
                    _context.Set<StdPrice>().Where(p => p.Status == true),
                    std => std.Id,
                    price => price.StdId,
                    (std, prices) => new { std, prices }
                )
                .SelectMany(
                    x => x.prices.OrderBy(p => p.Id).Take(2).DefaultIfEmpty(),
                    (x, price) => new AutoSearchResponseDto
                    {
                        Id = x.std.Id,
                        StandardNo = x.std.StandardNo,
                        Title = x.std.Title,
                        Description = x.std.StdKeyword,
                        SdoId = x.std.SdoId,
                        StandardId = x.std.StandardId,
                        MemberPriceRate = price != null ? price.MemberPriceRate : null,
                        NonMemberPriceRate = price != null ? price.NonMemberPriceRate : null,
                        formatID = price != null? price.FormateId : null
                    }
                );
        }
        else
        {
            finalQuery = query
                .Select(s => new AutoSearchResponseDto
                {
                    Id = s.Id,
                    StandardNo = s.StandardNo,
                    Title = s.Title,
                    Description = s.StdKeyword,
                    SdoId = s.SdoId,
                    StandardId = s.StandardId,
                    MemberPriceRate = null,
                    NonMemberPriceRate = null,
                    formatID = null
                });
        }


        // 8. Fetch all results
        var allResults = await finalQuery.ToListAsync();

        // 9. Apply relevance ranking in memory
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

        // 10. Apply paging
        var data = rankedResults
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(x => x.Entity)
            .ToList();

        // 11. Response
        return new PagedResponseDto<AutoSearchResponseDto>
        {
            Page = request.Page,
            PageSize = request.PageSize,
            TotalRecords = totalRecords,
            Data = data
        };
    }

    private static PagedResponseDto<AutoSearchResponseDto> EmptyResponse(
        AutoSearchRequestDto request)
    {
        return new PagedResponseDto<AutoSearchResponseDto>
        {
            Page = request.Page,
            PageSize = request.PageSize,
            TotalRecords = 0,
            Data = new List<AutoSearchResponseDto>()
        };
    }
}
