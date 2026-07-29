using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagement_2._0.Models;

public partial class Transaction
{
    [Key]
    public long Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Alias { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal PaidAmount { get; set; }

    public DateOnly Date { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string ReceivedBy { get; set; } = null!;

    [StringLength(30)]
    [Unicode(false)]
    public string PaymentMode { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string? Remark { get; set; }

    [ForeignKey("Alias")]
    [InverseProperty("Transactions")]
    public virtual Customer AliasNavigation { get; set; } = null!;
}
