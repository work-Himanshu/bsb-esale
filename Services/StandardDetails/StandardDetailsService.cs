using BSBESales.Data;
using BSBESales.DTOs.Standards;
using BSBESales.Models;
using Microsoft.EntityFrameworkCore;
namespace BSBESales.Services.StandardDetails;

public class StandardDetailsService:  IStandardDetailsService
{
    private readonly AppDbContext _context;
    public StandardDetailsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<StandardDetailsResponse>> GetStandardDetailsandPrice(string StandardId)
    {
        return await _context.StandardDetails
            .Where(sd => sd.Id.ToString() == StandardId)
            .GroupJoin(
                _context.StdPrices.Where(p => p.Status == true),
                sd => sd.Id,
                price => price.StdId,
                (sd, prices) => new { sd, prices }
            )
            .SelectMany(
                x => x.prices.OrderBy(p => p.Id).Take(2).DefaultIfEmpty(),
                (x, price) => new StandardDetailsResponse
                {
                    Id = x.sd.Id,
                    Content = x.sd.Content,
                    ReaffirmationYear = x.sd.ReaffirmationYear,
                    ReaffirmationDate = x.sd.ReaffirmationDate,
                    StdKeyword = x.sd.StdKeyword,
                    StdScope = x.sd.StdScope,
                    Pages = x.sd.Pages,
                    Edition = x.sd.Edition,
                    MetaTitle = x.sd.MetaTitle,
                    MetaKeyword = x.sd.MetaKeyword,
                    MetaDescription = x.sd.MetaDescription,
                    UpdatedAt = x.sd.UpdatedAt,
                    MetaUpdated = x.sd.MetaUpdated,
                    MemberPriceRate = price != null ? price.MemberPriceRate : null,
                    NonMemberPriceRate = price != null ? price.NonMemberPriceRate : null,
                    formatID = price != null ? price.FormateId : null
                }
            )
            .ToListAsync();
    }
}