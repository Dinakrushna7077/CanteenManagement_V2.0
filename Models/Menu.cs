using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagement_2._0.Models;

[Table("Menu")]
public partial class Menu
{
    [Key]
    public int Id { get; set; }

    [StringLength(15)]
    public string Day { get; set; } = null!;

    [Column("Break_First")]
    [StringLength(250)]
    public string BreakFirst { get; set; } = null!;

    [StringLength(300)]
    public string Lunch { get; set; } = null!;

    [StringLength(300)]
    public string Dinner { get; set; } = null!;

    [StringLength(200)]
    public string? Extra { get; set; }
}
