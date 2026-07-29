using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagement_2._0.Models;

[Table("AttendanceExtra")]
public partial class AttendanceExtra
{
    [Key]
    public int Id { get; set; }

    [Column("Att_Id")]
    public int AttId { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    [ForeignKey("AttId")]
    [InverseProperty("AttendanceExtras")]
    public virtual Attendance Att { get; set; } = null!;
}
