namespace VirtualShopping.Product.DTOs;
using VirtualShopping.Product.Models;

public class CategoryDTO
{
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public ICollection<Product>? Products { get; set; }
}
