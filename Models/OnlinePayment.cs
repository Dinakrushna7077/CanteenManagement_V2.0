using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagement_2._0.Models;

[Table("OnlinePayment")]
public partial class OnlinePayment
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    public string Alias { get; set; } = null!;

    [StringLength(100)]
    public string TnxId { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Amount { get; set; }

    [StringLength(255)]
    public string? Image { get; set; }

    [StringLength(20)]
    public string PayStatus { get; set; } = null!;

    [ForeignKey("Alias")]
    [InverseProperty("OnlinePayments")]
    public virtual Customer AliasNavigation { get; set; } = null!;
}
