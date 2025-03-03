using VirtualShopping.Product.DTOs;

namespace VirtualShopping.Product.Services.Contracts
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductsById(int id);
        Task AddProduct(ProductDTO productDTO);
        Task UpdateProduct(ProductDTO productDTO);
        Task RemoveProduct(int id);
    }
}
