using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualShopping.Product.DTOs;
using VirtualShopping.Product.Services;

namespace VirtualShopping.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categoriesDtos = await _categoryServices.GetCategories();

            if (categoriesDtos is null)
                return NotFound("Categories not found");

            return Ok(categoriesDtos);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
        {
            var categoriesDtos = await _categoryServices.GetCategoriesProducts();

            if (categoriesDtos is null)
                return NotFound("Categories not found");

            return Ok(categoriesDtos);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id) // Alterado para ActionResult<CategoryDTO>
        {
            var categoryDto = await _categoryServices.GetCategoriesById(id);

            if (categoryDto is null)
                return NotFound("Category not found");

            return Ok(categoryDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO is null)
                return BadRequest("Invalid data");

            await _categoryServices.AddCategory(categoryDTO);

            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryDTO.CategoryId }, categoryDTO); 
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.CategoryId)
                return BadRequest();

            if (categoryDTO is null)
                return BadRequest("Invalid data");

            await _categoryServices.UpdateCategory(categoryDTO);

            return NoContent(); 
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var categoryDto = await _categoryServices.GetCategoriesById(id); 

            if (categoryDto is null)
                return NotFound("Category not found");

            await _categoryServices.RemoveCategory(id);

            return Ok(categoryDto);
        }
    }
}
