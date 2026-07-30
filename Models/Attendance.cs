using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagement_2._0.Models;

[Table("Attendance")]
public partial class Attendance
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    public string Alias { get; set; } = null!;

    public DateOnly Date { get; set; }

    public bool BreakFast { get; set; }

    public bool Lunch { get; set; }

    public bool Dinner { get; set; }

    [ForeignKey("Alias")]
    [InverseProperty("Attendances")]
    public virtual Customer AliasNavigation { get; set; } = null!;

    [InverseProperty("Att")]
    public virtual ICollection<AttendanceExtra> AttendanceExtras { get; set; } = new List<AttendanceExtra>();
}
