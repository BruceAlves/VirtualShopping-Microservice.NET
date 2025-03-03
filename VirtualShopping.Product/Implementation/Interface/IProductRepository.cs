namespace VirtualShopping.Product.Implementation.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Models.Product>> GetAll();
        Task<Models.Product> GetById(int id);
        Task<Models.Product> Create(Models.Product product);
        Task<Models.Product> Update(Models.Product product);
        Task<Models.Product> Delete(int id);
    }
}
