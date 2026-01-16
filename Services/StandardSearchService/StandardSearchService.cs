using BSBESales.Data;
using BSBESales.DTOs.Search;
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
        // DateTime startDate = new DateTime(2018, 5, 1);
        // DateTime endDate   = new DateTime(2020, 5, 1);

        return await _context.Standards
            .Where(s =>
                s.StdDate.HasValue &&
                s.StdDate.Value >= request.StartDate &&
                s.StdDate.Value <= request.EndDate
            )
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
