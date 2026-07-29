using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagement_2._0.Models;

[Index("AdharNo", Name = "UQ__Admins__11C1127F08CEA9B7", IsUnique = true)]
[Index("UserId", Name = "UQ__Admins__1788CC4D3BCEEF15", IsUnique = true)]
public partial class Admin
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string AdminName { get; set; } = null!;

    [StringLength(250)]
    [Unicode(false)]
    public string? AdminAddress { get; set; }

    [StringLength(12)]
    [Unicode(false)]
    public string AdharNo { get; set; } = null!;

    public long UserId { get; set; }

    [InverseProperty("ApprovedByNavigation")]
    public virtual ICollection<MealLog> MealLogs { get; set; } = new List<MealLog>();

    [ForeignKey("UserId")]
    [InverseProperty("Admin")]
    public virtual User User { get; set; } = null!;
}
