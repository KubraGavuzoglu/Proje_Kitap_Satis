using Kitap.Data;
using Kitap.Data.Concrete;
using Kitap.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.Service.Concrete
{
    public class ProductService : ProductRepository, IProductService
    {
        public ProductService(DatabaseContext _context) : base(_context)
        {
        }
    }
}
