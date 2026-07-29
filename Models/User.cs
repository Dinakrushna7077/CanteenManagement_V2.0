using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagement_2._0.Models;

[Index("MobileNo", Name = "UQ__Users__D6D73A86290A0EEC", IsUnique = true)]
[Index("GmailId", Name = "UQ__Users__EAD496F4BAFAE513", IsUnique = true)]
public partial class User
{
    [Key]
    public long Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string GmailId { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string MobileNo { get; set; } = null!;

    [StringLength(255)]
    [Unicode(false)]
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
