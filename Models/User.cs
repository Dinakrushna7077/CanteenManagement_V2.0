using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagement_2._0.Models;

public partial class User
{
    [Key]
    public long Id { get; set; }

    [StringLength(255)]
    public string GmailId { get; set; } = null!;

    [StringLength(10)]
    public string MobileNo { get; set; } = null!;

    [StringLength(255)]
    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public bool ActiveStatus { get; set; }

    [InverseProperty("User")]
    public virtual Admin? Admin { get; set; }

    [InverseProperty("User")]
    public virtual Customer? Customer { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual UserRole Role { get; set; } = null!;
}
