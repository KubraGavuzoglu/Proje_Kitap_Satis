using Kitap.Data.Abstract;
using Kitap.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.Service.Abstract
{
    public interface IService<T> : IRepository<T> where T : class , IEntity , new()
    {

    }
}
