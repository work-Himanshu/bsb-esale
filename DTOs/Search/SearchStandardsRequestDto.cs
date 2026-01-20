using System.ComponentModel.DataAnnotations;

namespace BSBESales.DTOs.Search;

public class SearchStandardsRequestDto
{
    [Required] public string sdoID { get; set; }
    public int? Year { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}