namespace BSBESales.DTOs.Search;

public class SearchStandardResponseDto
{
    public int Id { get; set; }
    public string? StandardNo { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int SdoId { get; set; }
}