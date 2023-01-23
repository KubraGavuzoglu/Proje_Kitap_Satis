using Kitap.Data.Abstract;
using Kitap.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.Data.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext _context) : base(_context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductByCategoriesBrandsAsync()
        {
            return await context.Products.Include(c => c.Category).Include(b => b.Brand).ToListAsync();
        }
    }
}
