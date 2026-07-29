using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagement_2._0.Models;

[Table("OnlinePayment")]
[Index("TnxId", Name = "UQ__OnlinePa__11FBA1B3BF776911", IsUnique = true)]
public partial class OnlinePayment
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Alias { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string TnxId { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Amount { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Image { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string PayStatus { get; set; } = null!;

    [ForeignKey("Alias")]
    [InverseProperty("OnlinePayments")]
    public virtual Customer AliasNavigation { get; set; } = null!;
}
