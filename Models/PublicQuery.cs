using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagement_2._0.Models;

[Table("Public_Query")]
public partial class PublicQuery
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(10)]
    public string Mobile { get; set; } = null!;

    [Column("GMail")]
    [StringLength(255)]
    public string Gmail { get; set; } = null!;

    public string Query { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [StringLength(20)]
    public string Status { get; set; } = null!;
}
