using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagement_2._0.Models;

[Table("Public_Query")]
public partial class PublicQuery
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string Mobile { get; set; } = null!;

    [Column("GMail")]
    [StringLength(255)]
    [Unicode(false)]
    public string Gmail { get; set; } = null!;

    [Unicode(false)]
    public string Query { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string Status { get; set; } = null!;
}
