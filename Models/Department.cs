using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagement_2._0.Models;

[Table("Department")]
[Index("DeptName", Name = "UQ__Departme__5E5082653037CE79", IsUnique = true)]
public partial class Department
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string DeptName { get; set; } = null!;

    [InverseProperty("Department")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [InverseProperty("Dept")]
    public virtual ICollection<Honour> Honours { get; set; } = new List<Honour>();
}
