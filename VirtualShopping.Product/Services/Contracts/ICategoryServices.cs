using VirtualShopping.Product.DTOs;

namespace VirtualShopping.Product.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<IEnumerable<CategoryDTO>> GetCategoriesProducts();
        Task<CategoryDTO> GetCategoriesById(int id);
        Task AddCategory(CategoryDTO categoryDTO);
        Task UpdateCategory(CategoryDTO categoryDTO);
        Task RemoveCategory(int id);
    }
}
