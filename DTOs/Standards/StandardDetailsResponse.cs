namespace BSBESales.DTOs.Standards;

public class StandardDetailsResponse
{
    public int Id { get; set; }

    public string? Content { get; set; }

    public short? ReaffirmationYear { get; set; }

    public DateTime? ReaffirmationDate { get; set; }

    public string? StdKeyword { get; set; }

    public string? StdScope { get; set; }

    public string? Pages { get; set; }

    public string? Edition { get; set; }

    public string? MetaTitle { get; set; }

    public string? MetaKeyword { get; set; }

    public string? MetaDescription { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool MetaUpdated { get; set; }
    public decimal? MemberPriceRate { get; set; }
    public decimal? NonMemberPriceRate { get; set; }
    public int? formatID { get; set; }
}