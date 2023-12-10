using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingListApp.Domain.Entities;
public class ShoppingList
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ShoppingListID { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            ErrorMessage = "Please enter a valid email")]
    public string UserName { get; set; }
    [Required]
    [MaxLength(20)]
    public string Month { get; set; }
    [Required]
    [MaxLength(4)]
    public string Year { get; set; }
    [Required]
    public List<ShoppingItem> ShoppingItems { get; set; }
}
