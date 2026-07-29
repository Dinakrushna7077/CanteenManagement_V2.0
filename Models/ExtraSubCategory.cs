using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagement_2._0.Models;

[Table("ExtraSubCategory")]
[Index("Name", Name = "UQ__ExtraSub__737584F6A159FEDB", IsUnique = true)]
public partial class ExtraSubCategory
{
    [Key]
    public int Id { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("ExtraSubCategories")]
    public virtual ExtraItemCategory Category { get; set; } = null!;

    [InverseProperty("SubCategory")]
    public virtual ICollection<ExtraItem> ExtraItems { get; set; } = new List<ExtraItem>();
}
