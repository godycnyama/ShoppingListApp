﻿using System.ComponentModel.DataAnnotations;

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
