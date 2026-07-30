using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagement_2._0.Models;
public partial class Admin
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string AdminName { get; set; } = null!;

    [StringLength(250)]
    public string? AdminAddress { get; set; }

    [StringLength(12)]
    public string AdharNo { get; set; } = null!;

    public long UserId { get; set; }

    [InverseProperty("ApprovedByNavigation")]
    public virtual ICollection<MealLog> MealLogs { get; set; } = new List<MealLog>();

    [ForeignKey("UserId")]
    [InverseProperty("Admin")]
    public virtual User User { get; set; } = null!;
}
