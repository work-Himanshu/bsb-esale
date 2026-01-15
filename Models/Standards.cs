
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSBESales.Models;

[Table("standards")]
public class Standards
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("Standard_id")]
    [MaxLength(150)]
    public string StandardId { get; set; }

    [Column("sdo_id")]
    public int SdoId { get; set; }

    [Column("currency_id")]
    public int CurrencyId { get; set; }

    [Column("identifier_id")]
    public int? IdentifierId { get; set; }

    [Column("ics_links")]
    [MaxLength(255)]
    public string? IcsLinks { get; set; }

    [Column("stdtype")]
    [MaxLength(255)]
    public string? StdType { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("parent_id")]
    public int ParentId { get; set; }

    [Column("image")]
    [MaxLength(255)]
    public string? Image { get; set; }

    [Required]
    [Column("standardno")]
    [MaxLength(255)]
    public string StandardNo { get; set; }

    [Column("standardyear")]
    public short? StandardYear { get; set; }

    [Column("stddate")]
    public DateTime? StdDate { get; set; }

    [Column("title")]
    [MaxLength(1000)]
    public string? Title { get; set; }

    [Column("std_identifier")]
    public int StdIdentifier { get; set; }

    [Column("url")]
    [MaxLength(1000)]
    public string? Url { get; set; }

    [Column("recent")]
    public bool Recent { get; set; }

    [Column("mostpopular")]
    public bool MostPopular { get; set; }

    [Column("featured")]
    public bool Featured { get; set; }

    [Column("withdrawndate")]
    public DateTime? WithdrawnDate { get; set; }

    [Column("archive")]
    public bool Archive { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("display_stdNo")]
    [MaxLength(255)]
    public string? DisplayStdNo { get; set; }

    [Column("price_sdo")]
    [MaxLength(20)]
    public string? PriceSdo { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("updated_by")]
    public int? UpdatedBy { get; set; }

    [Column("status")]
    public bool Status { get; set; }

    [Column("AmendsId")]
    public int AmendsId { get; set; }

    [Column("BSBESales")]
    public bool BSBESales { get; set; }

    [Column("BSBInternal")]
    public bool BSBInternal { get; set; }

    [Column("BSBSubscription")]
    public bool BSBSubscription { get; set; }

    [Column("DocumentAvailability")]
    public bool DocumentAvailability { get; set; }

}
