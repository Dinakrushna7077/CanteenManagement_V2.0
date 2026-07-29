using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CanteenManagement_2._0.Models;

public partial class ExtraItem
{
    [Key]
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public int? SubCategoryId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("ExtraItems")]
    public virtual ExtraItemCategory Category { get; set; } = null!;

    [ForeignKey("SubCategoryId")]
    [InverseProperty("ExtraItems")]
    public virtual ExtraSubCategory? SubCategory { get; set; }
}
