using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagement_2._0.Models;

public partial class Honour
{
    [Key]
    public int Id { get; set; }

    public int DeptId { get; set; }

    [StringLength(50)]
    public string HonoursName { get; set; } = null!;

    [StringLength(10)]
    public string HonoursCode { get; set; } = null!;

    [InverseProperty("Honours")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [ForeignKey("DeptId")]
    [InverseProperty("Honours")]
    public virtual Department Dept { get; set; } = null!;
}
