using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagement_2._0.Models;

[Table("Amount")]
public partial class Amount
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    public string Alias { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Balance { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    [StringLength(300)]
    public string? Remark { get; set; }

    [ForeignKey("Alias")]
    [InverseProperty("Amount")]
    public virtual Customer AliasNavigation { get; set; } = null!;
}
