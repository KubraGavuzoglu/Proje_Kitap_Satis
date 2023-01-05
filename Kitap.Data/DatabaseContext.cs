using Kitap.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitap.Data
{
    public class DatabaseContext : DbContext
    {

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Burası veritabanı yapılandırma ayarlarını yapabileceğimiz metot
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; database=Proje_Kitap_Satis; integrated security=true;");
            //optionsBuilder.UseInMemoryDatabase("NetCoreMvcProjeUygulamasi");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(

                new User
                {

                    Id = 1,
                    Phone = "",
                    Email = "admin@blogsitesi.com",
                    IsActive = true,
                    IsAdmin = true,
                    Name = "admin",
                    Surname = "admin",
                    Password = "123"

                }

                );

            // Burası veritabanımız oluştuktan sonra model classları ile ilgili işlemlerin yapılabileceği metot
            base.OnModelCreating(modelBuilder);
        }
    }
}
