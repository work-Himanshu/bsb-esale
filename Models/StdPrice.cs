using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BSBESales.Models;

[Table("std_prices")]
public class StdPrice
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("std_id")]
    public int StdId { get; set; }

    [Column("formate_id")]
    public int? FormateId { get; set; }

    [Column("language_id")]
    public int? LanguageId { get; set; }

    [Column("member_price_rate", TypeName = "decimal(10,2)")]
    public decimal? MemberPriceRate { get; set; }

    [Column("member_price_group")]
    [StringLength(5)]
    public string? MemberPriceGroup { get; set; }

    [Column("non_member_price_rate", TypeName = "decimal(10,2)")]
    public decimal? NonMemberPriceRate { get; set; }

    [Column("non_member_price_group")]
    [StringLength(5)]
    public string? NonMemberPriceGroup { get; set; }

    [Column("weight")]
    [StringLength(255)]
    public string? Weight { get; set; }

    [Column("filename")]
    [StringLength(255)]
    public string? FileName { get; set; }

    [Column("file")]
    [StringLength(255)]
    public string? File { get; set; }

    [Column("discount")]
    [StringLength(255)]
    public string? Discount { get; set; }

    [Column("given_std_id")]
    [StringLength(255)]
    public string? GivenStdId { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [Column("del_format")]
    public short? DelFormat { get; set; }

    [Column("sdo_id")]
    public int? SdoId { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("updated_by")]
    public int? UpdatedBy { get; set; }

    [Column("status")]
    public bool? Status { get; set; }

    [Column("PurchaseAgencyId")]
    public int? PurchaseAgencyId { get; set; }

    [Column("EdgeQuantity")]
    public int EdgeQuantity { get; set; }

    [Column("BSBQuantity")]
    public int BSBQuantity { get; set; }

    [Column("ReorderLvl")]
    public int ReorderLvl { get; set; }

    [Column("EdgeOrderInHand")]
    public int EdgeOrderInHand { get; set; }

    [Column("BSBOrderInHand")]
    public int BSBOrderInHand { get; set; }

    [Column("IhsQuantity")]
    public int IhsQuantity { get; set; }

    [Column("IhsOrderInHand")]
    public int IhsOrderInHand { get; set; }
}
