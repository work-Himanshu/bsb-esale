using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSBESales.Models;

[Table("StandardDetails")]
public class StandardDetails
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("content")]
    public string? Content { get; set; }

    [Column("reaffyear")]
    public short? ReaffirmationYear { get; set; }

    [Column("reaffdate")]
    public DateTime? ReaffirmationDate { get; set; }

    [Column("stdkeyword")]
    public string? StdKeyword { get; set; }

    [Column("stdscope")]
    public string? StdScope { get; set; }

    [Column("pages")]
    [StringLength(255)]
    public string? Pages { get; set; }

    [Column("edition")]
    [StringLength(255)]
    public string? Edition { get; set; }

    [Column("meta_title")]
    public string? MetaTitle { get; set; }

    [Column("meta_keyword")]
    public string? MetaKeyword { get; set; }

    [Column("meta_description")]
    public string? MetaDescription { get; set; }

    [Column("UpdatedAt")]
    public DateTime? UpdatedAt { get; set; }

    [Column("meta_updated")]
    public bool MetaUpdated { get; set; }
    
}
