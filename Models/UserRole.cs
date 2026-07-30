using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagement_2._0.Models;

[Table("UserRole")]
public partial class UserRole
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    public string RoleName { get; set; } = null!;

    [StringLength(200)]
    public string? Description { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
