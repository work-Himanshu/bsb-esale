namespace BSBESales.DTOs.Sdos;

public class sdosResponse
{
    public int Id { get; set; }

    public string SdoTitle { get; set; }
    public string SdoFullName { get; set; }

    public string Url { get; set; }
    public int? CurrencyId { get; set; }

    public string SdoShortDesc { get; set; }
    public string SdoDetailDesc { get; set; }

    public string SdoBanner { get; set; }
    public string SdoUploadFile { get; set; }

    public bool Watermark { get; set; }
    public byte Status { get; set; }
    public bool Promote { get; set; }

    public string MetaTitle { get; set; }
    public string MetaKeyword { get; set; }
    public string MetaDescription { get; set; }

    public bool BSBESales { get; set; }
    public bool BSBInternal { get; set; }
    public bool BSBSubscription { get; set; }

    public int DailyDownloadLimit { get; set; }

    public string ContactName { get; set; }
    public string Designation { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public DateTime? CreatedAt { get; set; }
}