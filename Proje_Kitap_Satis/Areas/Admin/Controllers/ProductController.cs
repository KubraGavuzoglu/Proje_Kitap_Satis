using Kitap.Entities;
using Kitap.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proje_Kitap_Satis.Utils;

namespace Proje_Kitap_Satis.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IService<Product> _service;
        private readonly IService<Category> _serviceCategory;
        private readonly IService<Brand> _serviceBrand;
        private readonly IProductService _productService;

        public ProductController(IService<Product> service, IService<Category> serviceCategory, IService<Brand> serviceBrand, IProductService productService)
        {
            _service = service;
            _serviceCategory = serviceCategory;
            _serviceBrand = serviceBrand;
            _productService = productService;
        }



        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            var model = await _productService.GetAllProductByCategoriesBrandsAsync();
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public async Task<ActionResult> CreateAsync()
        {
            ViewBag.CategoryId=new SelectList(await _serviceCategory.GetAllAsync(),"Id","Name");
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");

            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Product product , IFormFile? Image)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if(Image is not null) product.Image=await FileHelper.FileLoaderAsync(Image );
                    await _service.AddAsync(product);
                    await _service.SaveChangesAsync();


                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu");
                }



            }

            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");

            return View(product);


        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);
            ViewBag.CategoryId = new SelectList(await _serviceCategory.GetAllAsync(), "Id", "Name");
            ViewBag.BrandId = new SelectList(await _serviceBrand.GetAllAsync(), "Id", "Name");

            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Product product , IFormFile? Image)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if (Image is not null) product.Image = await FileHelper.FileLoaderAsync(Image);
                    _service.Update(product);
                    await _service.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu");

                }


            }

            

            return View(product);

        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model =await  _service.FindAsync(id);

            return View(model);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Product product)
        {
            try
            {
                _service.Delete(product);
               await  _service.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
