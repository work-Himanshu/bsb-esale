using BSBESales.Data;
using BSBESales.DTOs.Search;
using BSBESales.Models;
using Microsoft.EntityFrameworkCore;

namespace BSBESales.Services.StandardSearchService;

public class StandardSearchService : IStandardSearchService
{
    private readonly AppDbContext _context;

    public StandardSearchService(AppDbContext context)
    {
        _context = context;
    }

public async Task<List<SearchStandardsResponseDto>> SearchingStandards(
    SearchStandardsRequestDto request)
{
    IQueryable<Standards> query = _context.Standards
        .AsNoTracking();

    // 1. SDO filter
    if (!string.IsNullOrWhiteSpace(request.sdoID) &&
        int.TryParse(request.sdoID, out int sdoId))
    {
        query = query.Where(s => s.SdoId == sdoId);
    }

    // 2. Start Date filter
    if (request.StartDate.HasValue)
    {
        query = query.Where(s => s.StdDate.HasValue && s.StdDate.Value >= request.StartDate.Value);
    }

    // 3. End Date filter
    if (request.EndDate.HasValue)
    {
        query = query.Where(s => s.StdDate.HasValue && s.StdDate.Value <= request.EndDate.Value);
    }

    // 4. Year filter
    if (request.Year.HasValue)
    {
        query = query.Where(s =>
            s.StandardYear.HasValue &&
            s.StandardYear.Value == request.Year.Value);
    }

    return await query
        .OrderByDescending(s => s.StdDate)
        .Take(10)
        .Select(s => new SearchStandardsResponseDto
        {
            Id = s.Id,
            StandardId = s.StandardId,
            SdoId = s.SdoId,
            CurrencyId = s.CurrencyId,
            IdentifierId = s.IdentifierId,
            IcsLinks = s.IcsLinks,
            StdType = s.StdType,
            StatusId = s.StatusId,
            ParentId = s.ParentId,
            Image = s.Image,
            StandardNo = s.StandardNo,
            StandardYear = s.StandardYear,
            StdDate = s.StdDate,
            Title = s.Title,
            StdIdentifier = s.StdIdentifier,
            Url = s.Url,
            Recent = s.Recent,
            MostPopular = s.MostPopular,
            Featured = s.Featured,
            WithdrawnDate = s.WithdrawnDate,
            Archive = s.Archive,
            DisplayStdNo = s.DisplayStdNo,
            PriceSdo = s.PriceSdo,
            Status = s.Status,
            AmendsId = s.AmendsId,
            BSBESales = s.BSBESales,
            BSBInternal = s.BSBInternal,
            BSBSubscription = s.BSBSubscription,
            DocumentAvailability = s.DocumentAvailability
        })
        .ToListAsync();
}

}
