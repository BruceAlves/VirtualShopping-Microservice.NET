﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualShopping.Product.DTOs;
using VirtualShopping.Product.Services.Contracts;

namespace VirtualShopping.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet] 
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var productsDtos = await _productServices.GetProducts();

            if (productsDtos is null)
                return NotFound("Products not found");

            return Ok(productsDtos);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var productDto = await _productServices.GetProductsById(id);

            if (productDto is null)
                return NotFound("Product not found"); 

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if (productDTO is null)
                return BadRequest("Invalid data");

            await _productServices.AddProduct(productDTO);

            return CreatedAtAction(nameof(GetProductById), new { id = productDTO.Id }, productDTO); 
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDTO)
        {
            if (id != productDTO.Id)
                return BadRequest();

            if (productDTO is null)
                return BadRequest("Invalid data");

            await _productServices.UpdateProduct(productDTO);

            return NoContent(); 
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var productDto = await _productServices.GetProductsById(id); 

            if (productDto is null)
                return NotFound("Product not found"); 

            await _productServices.RemoveProduct(id);

            return Ok(productDto);
        }
    }
}
