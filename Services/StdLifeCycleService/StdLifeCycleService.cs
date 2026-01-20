using Microsoft.EntityFrameworkCore;
using BSBESales.Data;
using BSBESales.DTOs.Standards;
namespace BSBESales.Services.StdLifeCycleService;

public class StdLifeCycleService : IStdLifeCycleService
{
    private readonly AppDbContext _context;

    public StdLifeCycleService(AppDbContext context)
    {
        _context=context;
    }

    public async Task<List<response_StandardDTOs>> GetStandardWithAllParents(int id)
    {
        var result = new List<response_StandardDTOs>();

        int currentId = id;
        int level = 0;
        const int maxLevels = 5;
        while (currentId != 0 && level < maxLevels)
        {
            var standard = await _context.Standards
                .Where(s => s.Id == currentId)
                .Select(s => new response_StandardDTOs
                {   Id = s.Id,
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
                    ParentId = s.ParentId
                })
                .FirstOrDefaultAsync();

            if (standard == null)
                break;

            result.Add(standard);

            currentId = standard.ParentId;
            level++;
        }

        return result;
    }

}