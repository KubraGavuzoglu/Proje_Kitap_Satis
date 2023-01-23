using Kitap.Entities;

namespace Kitap.Data.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProductByCategoriesBrandsAsync(); 

    }
}
