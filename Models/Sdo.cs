using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSBESales.Models;

public class Sdo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("sdo_title")]
    [MaxLength(255)]
    public string SdoTitle { get; set; } = string.Empty;

    [Required]
    [Column("sdo_fullname")]
    [MaxLength(255)]
    public string SdoFullname { get; set; } = string.Empty;

    [Column("access_list", TypeName = "longtext")]
    public string? AccessList { get; set; }

    [Column("url")]
    [MaxLength(255)]
    public string? Url { get; set; }

    [Column("currency_id")]
    public int? CurrencyId { get; set; }

    [Column("sdo_shortdesc", TypeName = "text")]
    public string? SdoShortdesc { get; set; }

    [Column("sdo_detaildesc", TypeName = "text")]
    public string? SdoDetaildesc { get; set; }

    [Column("sdo_banner")]
    [MaxLength(255)]
    public string? SdoBanner { get; set; }

    [Column("sdo_uploadfile")]
    [MaxLength(255)]
    public string? SdoUploadfile { get; set; }

    [Column("watermark")]
    public bool Watermark { get; set; } = false;

    [Required]
    [Column("status")]
    public byte Status { get; set; } = 0;

    [Column("promote")]
    public bool Promote { get; set; } = false;

    [Column("meta_title")]
    [MaxLength(500)]
    public string? MetaTitle { get; set; }

    [Column("meta_keyword", TypeName = "text")]
    public string? MetaKeyword { get; set; }

    [Column("meta_description", TypeName = "text")]
    public string? MetaDescription { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("updated_by")]
    public int? UpdatedBy { get; set; }

    [Column("created_at")]
    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    [Column("structure_data", TypeName = "longtext")]
    public string? StructureData { get; set; }

    [Column("free_structure_data", TypeName = "longtext")]
    public string? FreeStructureData { get; set; }

    [Column("free_meta_title")]
    [MaxLength(500)]
    public string? FreeMetaTitle { get; set; }

    [Column("free_meta_description", TypeName = "text")]
    public string? FreeMetaDescription { get; set; }

    [Required]
    [Column("BSBESales")]
    public bool BSBESales { get; set; } = false;

    [Required]
    [Column("BSBInternal")]
    public bool BSBInternal { get; set; } = false;

    [Required]
    [Column("BSBSubscription")]
    public bool BSBSubscription { get; set; } = false;

    [Required]
    [Column("DailyDownloadLimit")]
    public int DailyDownloadLimit { get; set; } = 0;

    [Column("sdo_shortdesc_detail", TypeName = "text")]
    public string? SdoShortdescDetail { get; set; }

    [Column("address0")]
    [MaxLength(50)]
    public string? Address0 { get; set; }

    [Column("address1")]
    [MaxLength(50)]
    public string? Address1 { get; set; }

    [Column("address2")]
    [MaxLength(50)]
    public string? Address2 { get; set; }

    [Column("address3")]
    [MaxLength(50)]
    public string? Address3 { get; set; }

    [Column("contact_name")]
    [MaxLength(50)]
    public string? ContactName { get; set; }

    [Column("designation")]
    [MaxLength(50)]
    public string? Designation { get; set; }

    [Column("phone")]
    [MaxLength(50)]
    public string? Phone { get; set; }

    [Column("pincode")]
    [MaxLength(50)]
    public string? Pincode { get; set; }

    [Column("email")]
    [MaxLength(50)]
    public string? Email { get; set; }
}
