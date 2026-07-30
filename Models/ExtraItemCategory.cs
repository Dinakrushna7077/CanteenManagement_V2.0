using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagement_2._0.Models;

public partial class ExtraItemCategory
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("Category")]
    public virtual ICollection<ExtraItem> ExtraItems { get; set; } = new List<ExtraItem>();

    [InverseProperty("Category")]
    public virtual ICollection<ExtraSubCategory> ExtraSubCategories { get; set; } = new List<ExtraSubCategory>();
}
