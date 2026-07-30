using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenManagement_2._0.Models;

[Table("ExtraSubCategory")]
public partial class ExtraSubCategory
{
    [Key]
    public int Id { get; set; }

    [StringLength(150)]
    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("ExtraSubCategories")]
    public virtual ExtraItemCategory Category { get; set; } = null!;

    [InverseProperty("SubCategory")]
    public virtual ICollection<ExtraItem> ExtraItems { get; set; } = new List<ExtraItem>();
}
