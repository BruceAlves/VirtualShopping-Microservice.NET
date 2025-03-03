using AutoMapper;
using VirtualShopping.Product.DTOs;
using VirtualShopping.Product.Implementation.Interface;
using VirtualShopping.Product.Models;

namespace VirtualShopping.Product.Services.Implementations
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServices(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }



        public async Task AddCategory(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Create(categoryEntity);
            categoryDTO.CategoryId = categoryEntity.CategoryId;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetCategoriesById(int id)
        {
            var categoriesEntity = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(categoriesEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
        {
            var categoriesEntity = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task RemoveCategory(int id)
        {
            var categoryEntity = _categoryRepository.GetById(id); 
            await _categoryRepository.Delete(categoryEntity.Id);
        }

        public async Task UpdateCategory(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Update(categoryEntity);
        }
    }
}
