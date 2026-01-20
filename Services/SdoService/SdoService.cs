using Microsoft.EntityFrameworkCore;
using BSBESales.Data;
using BSBESales.DTOs.Sdos;
using BSBESales.Models;

namespace BSBESales.Services.SdoService;

public class SdoService : ISdoService
{
    private readonly AppDbContext _context;

    public SdoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<sdosResponse>> GetSdoList()
    {
        return await _context.sdos
            .Where(s => s.BSBESales)
            .OrderBy(s => s.Id)
            .Select(s => new sdosResponse
            {
                Id = s.Id,
                SdoTitle = s.SdoTitle,
                SdoFullName = s.SdoFullname,
                Url = s.Url,
                CurrencyId = s.CurrencyId,
                SdoShortDesc = s.SdoShortdesc,
                SdoDetailDesc = s.SdoShortdescDetail,
                SdoBanner = s.SdoBanner,
                SdoUploadFile = s.SdoUploadfile,
                Watermark = s.Watermark,
                Status = s.Status,
                Promote = s.Promote,
                MetaTitle = s.MetaTitle,
                MetaKeyword = s.MetaKeyword,
                MetaDescription = s.MetaDescription,
                BSBESales = s.BSBESales,
                BSBInternal = s.BSBInternal,
                BSBSubscription = s.BSBSubscription,
                DailyDownloadLimit = s.DailyDownloadLimit,
                ContactName = s.ContactName,
                Designation = s.Designation,
                Phone = s.Phone,
                Email = s.Email,
                CreatedAt = s.CreatedAt
            })
            .ToListAsync();
    }
}