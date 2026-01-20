
namespace BSBESales.DTOs.Search;

public class SearchStandardsResponseDto
{
    public int Id { get; set; }

    public string StandardId { get; set; } = null!;

    public int SdoId { get; set; }

    public int CurrencyId { get; set; }

    public int? IdentifierId { get; set; }

    public string? IcsLinks { get; set; }

    public string? StdType { get; set; }

    public int StatusId { get; set; }

    public int ParentId { get; set; }   

    public string? Image { get; set; }

    public string StandardNo { get; set; } = null!;

    public short? StandardYear { get; set; }

    public DateTime? StdDate { get; set; }

    public string? Title { get; set; }

    public int StdIdentifier { get; set; }

    public string? Url { get; set; }

    public bool Recent { get; set; }

    public bool MostPopular { get; set; }

    public bool Featured { get; set; }

    public DateTime? WithdrawnDate { get; set; }

    public bool Archive { get; set; }

    public string? DisplayStdNo { get; set; }

    public string? PriceSdo { get; set; }

    public bool Status { get; set; }

    public int AmendsId { get; set; }

    public bool BSBESales { get; set; }

    public bool BSBInternal { get; set; }

    public bool BSBSubscription { get; set; }

    public bool DocumentAvailability { get; set; }
}
