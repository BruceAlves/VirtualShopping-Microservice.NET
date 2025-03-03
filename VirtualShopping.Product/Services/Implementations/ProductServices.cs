using AutoMapper;
using VirtualShopping.Product.DTOs;
using VirtualShopping.Product.Implementation.Interface;
using VirtualShopping.Product.Implementation.Repository;
using VirtualShopping.Product.Models;
using VirtualShopping.Product.Services.Contracts;

namespace VirtualShopping.Product.Services.Implementations
{
    public class ProductServices : IProductServices
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductServices(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task AddProduct(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Models.Product>(productDTO);
            await _productRepository.Create(productEntity);
            productDTO.Id =  productEntity.Id;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var ProductsEntity = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(ProductsEntity);
        }

        public async Task<ProductDTO> GetProductsById(int id)
        {
            var ProductsEntity = await _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(ProductsEntity);
        }

        public async Task RemoveProduct(int id)
        {
            var productEntity = _productRepository.GetById(id);
            await _productRepository.Delete(productEntity.Id);
        }

        public async Task UpdateProduct(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Models.Product>(productDTO);
            await _productRepository.Update(productEntity);
        }
    }
}
