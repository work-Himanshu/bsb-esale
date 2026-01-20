namespace BSBESales.DTOs.Standards;

public class response_StandardDTOs
{
    public int Id { get; set; }

    public string StandardId { get; set; }
    public string StandardNo { get; set; }
    public string? DisplayStdNo { get; set; }

    public string? Title { get; set; }
    public short? StandardYear { get; set; }
    public DateTime? StdDate { get; set; }

    public int SdoId { get; set; }
    public int CurrencyId { get; set; }

    public string? Url { get; set; }
    public string? PriceSdo { get; set; }

    public bool Recent { get; set; }
    public bool MostPopular { get; set; }
    public bool Featured { get; set; }

    public bool BSBESales { get; set; }
    public bool BSBInternal { get; set; }
    public bool BSBSubscription { get; set; }
    public int ParentId { get; set; }
    public string? ParentStdNo { get; set; }
    public bool DocumentAvailability { get; set; }
}