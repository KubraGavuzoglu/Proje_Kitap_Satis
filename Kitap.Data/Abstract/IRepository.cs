using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.Data.Abstract
{
    public interface IRepository<T> where T : class //Irepository interface i için entitylerimiz için gerçekleştireceğimiz veritabanı işlemleriniyapacak olan repository class ında bulunması gereken metotların imzalarını tutuyor. <T> kodu bu interface e dışarıdan parametre olarak generic bir nesnenin gönderilebilmeini sağlar. where T: class kodu ise Tnin tipinin class olması gerektiğini belirler. böylece string gibi bir veri gönderilmeye kalkılırsa interface bunu kabul etmeyecektir.

    {

        List<T> GetAll(); // veritabanınındaki tüm kayıtlatı listeleyecek metot imzası
        List<T> GetAll(Expression<Func<T, bool>> expression); // getall mtodunda entity frameworkteki x=>x. eşklinde yazdığımız lambda expression ları kullanabilmekiç.

        T Get(Expression<Func<T, bool>> expression);
        // özel sorgu kullanarak bir tane kayıt getiren metot imzası
        T Find(int id);
        int Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int SaveChanges();
        //asenkron metotlar

        Task<T> FindAsync(int id);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> FindAllAsync(Expression<Func<T, bool>> expression);

        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);

        Task<int> SaveChangesAsync();








    }
}
