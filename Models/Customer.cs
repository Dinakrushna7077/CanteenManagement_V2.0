using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagement_2._0.Models;

[Table("Customer")]
[Index("UserId", Name = "UQ__Customer__1788CC4DAEAA5D8D", IsUnique = true)]
public partial class Customer
{
    [Key]
    [StringLength(20)]
    [Unicode(false)]
    public string Alias { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    public bool IsHosteler { get; set; }

    public long UserId { get; set; }

    public int? DepartmentId { get; set; }

    public int? HonoursId { get; set; }

    [Column("College_Roll")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CollegeRoll { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? Address { get; set; }

    [Column("Guardian_Mobile")]
    [StringLength(10)]
    [Unicode(false)]
    public string? GuardianMobile { get; set; }

    public bool MealStatus { get; set; }

    [InverseProperty("AliasNavigation")]
    public virtual Amount? Amount { get; set; }

    [InverseProperty("AliasNavigation")]
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    [ForeignKey("DepartmentId")]
    [InverseProperty("Customers")]
    public virtual Department? Department { get; set; }

    [ForeignKey("HonoursId")]
    [InverseProperty("Customers")]
    public virtual Honour? Honours { get; set; }

    [InverseProperty("AliasNavigation")]
    public virtual ICollection<MealLog> MealLogs { get; set; } = new List<MealLog>();

    [InverseProperty("AliasNavigation")]
    public virtual ICollection<OnlinePayment> OnlinePayments { get; set; } = new List<OnlinePayment>();

    [InverseProperty("AliasNavigation")]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    [ForeignKey("UserId")]
    [InverseProperty("Customer")]
    public virtual User User { get; set; } = null!;
}
