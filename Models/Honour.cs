using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagement_2._0.Models;

[Index("HonoursCode", Name = "UQ__Honours__867B9E19F8813052", IsUnique = true)]
public partial class Honour
{
    [Key]
    public int Id { get; set; }

    public int DeptId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string HonoursName { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string HonoursCode { get; set; } = null!;

    [InverseProperty("Honours")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [ForeignKey("DeptId")]
    [InverseProperty("Honours")]
    public virtual Department Dept { get; set; } = null!;
}
