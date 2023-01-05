using Kitap.Data;
using Kitap.Data.Concrete;
using Kitap.Entities;
using Kitap.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.Service.Concrete
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext _context) : base(_context)
        {

        }
    }
}
