using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagement_2._0.Models;

[Table("Amount")]
[Index("Alias", Name = "UQ__Amount__70F4A9E085A648EC", IsUnique = true)]
public partial class Amount
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Alias { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Balance { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    [StringLength(300)]
    [Unicode(false)]
    public string? Remark { get; set; }

    [ForeignKey("Alias")]
    [InverseProperty("Amount")]
    public virtual Customer AliasNavigation { get; set; } = null!;
}
