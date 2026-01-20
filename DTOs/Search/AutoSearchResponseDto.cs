namespace BSBESales.DTOs.Search;

public class AutoSearchResponseDto
{
    public int Id { get; set; }
    public string? StandardNo { get; set; }

    public string? Title { get; set; }
    public string? Description { get; set; }
    public int SdoId { get; set; }
    public string? StandardId { get; set; }
    public decimal? MemberPriceRate { get; set; }
    public decimal? NonMemberPriceRate { get; set; }
    public int? formatID { get; set; }
}