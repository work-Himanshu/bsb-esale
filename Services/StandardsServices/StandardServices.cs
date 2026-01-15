using Microsoft.EntityFrameworkCore;
using BSBESales.Data;
using BSBESales.DTOs.Standards;

namespace BSBESales.Services.StandardsServices;

public class StandardServices : IStandardServices
{
    private readonly AppDbContext _context;

    public StandardServices(AppDbContext context)
    {
        _context=context;
    }

    public async Task<List<response_StandardDTOs>> GetStandardList(string StandardId)
    {
        return await _context.Standards
            .Where(s => s.StandardId == StandardId)
            .Select(s => new response_StandardDTOs()
            {
                StandardId = s.StandardId,
                StandardNo = s.StandardNo,
                DisplayStdNo = s.DisplayStdNo,
                Title = s.Title,
                StandardYear = s.StandardYear,
                StdDate = s.StdDate,
                SdoId = s.SdoId,
                CurrencyId = s.CurrencyId,
                Url = s.Url,
                PriceSdo = s.PriceSdo,
                Recent = s.Recent,
                MostPopular = s.MostPopular,
                Featured = s.Featured,
                BSBESales = s.BSBESales,
                BSBInternal = s.BSBInternal,
                BSBSubscription = s.BSBSubscription,
            }).ToListAsync();
    }
}