using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Domain.Entities;
public class ShoppingItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ShoppingItemID { get; set; }
    [Required]
    public int ShoppingListID { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    [Column(TypeName = "decimal(5, 2)")]
    public decimal Cost { get; set; }
    [Required]
    [MaxLength(4)]
    public string Currency { get; set; }
    [MaxLength(200)]
    public string PhotoFileName { get; set; }
}

