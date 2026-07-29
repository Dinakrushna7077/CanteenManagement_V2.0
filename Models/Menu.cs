using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagement_2._0.Models;

[Table("Menu")]
[Index("Day", Name = "UQ__Menu__C0301F122EA2058E", IsUnique = true)]
public partial class Menu
{
    [Key]
    public int Id { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string Day { get; set; } = null!;

    [Column("Break_First")]
    [StringLength(250)]
    [Unicode(false)]
    public string BreakFirst { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string Lunch { get; set; } = null!;

    [StringLength(300)]
    [Unicode(false)]
    public string Dinner { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? Extra { get; set; }
}
