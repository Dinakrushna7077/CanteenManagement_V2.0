using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagement_2._0.Models;

public partial class MealLog
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    public string Alias { get; set; } = null!;

    [StringLength(10)]
    public string RequestType { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime RequestedOn { get; set; }

    [StringLength(10)]
    public string ApproveStatus { get; set; } = null!;

    public DateOnly? FromDate { get; set; }

    public DateOnly? ToDate { get; set; }

    [StringLength(300)]
    public string? Reason { get; set; }

    public int? ApprovedBy { get; set; }

    [ForeignKey("Alias")]
    [InverseProperty("MealLogs")]
    public virtual Customer AliasNavigation { get; set; } = null!;

    [ForeignKey("ApprovedBy")]
    [InverseProperty("MealLogs")]
    public virtual Admin? ApprovedByNavigation { get; set; }
}
