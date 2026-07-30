using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagement_2._0.Models;


public partial class Department
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string DeptName { get; set; } = null!;

    [InverseProperty("Department")]
    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    [InverseProperty("Dept")]
    public virtual ICollection<Honour> Honours { get; set; } = new List<Honour>();
}
