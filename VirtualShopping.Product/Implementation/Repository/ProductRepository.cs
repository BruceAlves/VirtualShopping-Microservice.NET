using Microsoft.EntityFrameworkCore;
using VirtualShopping.Product.Context;
using VirtualShopping.Product.Implementation.Interface;
using VirtualShopping.Product.Models;

namespace VirtualShopping.Product.Implementation.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Models.Product> Create(Models.Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Models.Product> Delete(int id)
        {
            var product = await GetById(id);
            _context.Products.Remove(product);
            return product;
        }

        public async Task<IEnumerable<Models.Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Models.Product> GetById(int id)
        {
            var product = await _context.Products
                               .Where(c => c.Id == id)
                               .FirstOrDefaultAsync();

            return product ?? new Models.Product();
        }

        public async Task<Models.Product> Update(Models.Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
