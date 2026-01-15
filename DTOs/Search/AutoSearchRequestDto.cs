namespace BSBESales.DTOs.Search;

public class SearchStandardRequestDto
{
    public string? Keyword { get; set; }

    public int? SdoId { get; set; }
    public int? StatusId { get; set; }

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}