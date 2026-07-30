using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagement_2._0.Models;

public partial class Transaction
{
    [Key]
    public long Id { get; set; }

    [StringLength(20)]
    public string Alias { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal PaidAmount { get; set; }

    public DateOnly Date { get; set; }

    [StringLength(100)]
    public string ReceivedBy { get; set; } = null!;

    [StringLength(30)]
    public string PaymentMode { get; set; } = null!;

    [StringLength(300)]
    public string? Remark { get; set; }

    [ForeignKey("Alias")]
    [InverseProperty("Transactions")]
    public virtual Customer AliasNavigation { get; set; } = null!;
}
