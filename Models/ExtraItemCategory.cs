using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagement_2._0.Models;

[Table("ExtraItemCategory")]
[Index("Name", Name = "UQ__ExtraIte__737584F6E20B0100", IsUnique = true)]
public partial class ExtraItemCategory
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<ExtraItem> ExtraItems { get; set; } = new List<ExtraItem>();

    [InverseProperty("Category")]
    public virtual ICollection<ExtraSubCategory> ExtraSubCategories { get; set; } = new List<ExtraSubCategory>();
}
