using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Domain.Entities;
public class ShoppingList
{
    [Key]
    public int ShoppingListID { get; set; }
    [Required]
    public int UserID { get; set; }
    [Required]
    [MaxLength(20)]
    public string Month { get; set; }
    [Required]
    [MaxLength(4)]
    public string Year { get; set; }
    [Required]
    public List<ShoppingItem> ShoppingItems { get; set; }
}
