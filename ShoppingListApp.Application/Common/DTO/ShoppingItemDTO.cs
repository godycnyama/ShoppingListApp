using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Application.Common.DTO;
public class ShoppingItemDTO
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public decimal Cost { get; set; }
    [Required]
    [MaxLength(4)]
    public string Currency { get; set; }
}
