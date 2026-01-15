namespace BSBESales.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("standards_search")]
public class SearchStandard
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    [Column("Standard_id")]
    public string StandardId { get; set; } = null!;

    [Required]
    [Column("sdo_id")]
    public int SdoId { get; set; }

    [Required]
    [Column("status_id")]
    public int StatusId { get; set; } = 1;

    [Required]
    [StringLength(100)]
    [Column("standardno")]
    public string StandardNo { get; set; } = null!;

    [Required]
    [StringLength(1000)]
    [Column("title")]
    public string Title { get; set; } = null!;

    [StringLength(1000)]
    [Column("url")]
    public string? Url { get; set; }

    [Column("stdkeyword", TypeName = "longtext")]
    public string? StdKeyword { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [StringLength(255)]
    [Column("display_stdNo")]
    public string? DisplayStdNo { get; set; }

    [Required]
    [StringLength(1000)]
    [Column("search_query")]
    public string SearchQuery { get; set; } = null!;

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("updated_by")]
    public int? UpdatedBy { get; set; }

    [Column("status")]
    public bool? Status { get; set; }
    
}
