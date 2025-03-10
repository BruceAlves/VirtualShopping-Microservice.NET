﻿using System.ComponentModel.DataAnnotations;

namespace VirtualShopping.Product.Models;

public class Category
{
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "The Name is Required")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }
    public ICollection<Product>?  Products { get; set; }
}
