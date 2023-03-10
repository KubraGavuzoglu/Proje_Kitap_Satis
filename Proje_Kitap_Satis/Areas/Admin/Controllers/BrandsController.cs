using Kitap.Entities;
using Kitap.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proje_Kitap_Satis.Utils;

namespace Proje_Kitap_Satis.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class BrandsController : Controller
    {

        private readonly IService<Brand> _service;

        public BrandsController(IService<Brand> service)
        {
            _service = service;
        }


        // GET: BrandsController
        public ActionResult Index()
        {
            var model=_service.GetAll();

            return View(model);
        }

        // GET: BrandsController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var model= await _service.FindAsync(id);

            return View(model);
        }

        // GET: BrandsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BrandsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Brand brand , IFormFile? Logo)
        {

            if(ModelState.IsValid)
            {

                try
                {
                    brand.Logo=await FileHelper.FileLoaderAsync(Logo);

                    _service.Add(brand);
                    _service.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {

                    ModelState.AddModelError("", "Hata oluştu");
                   
                }




            }

            return View(brand);




        }

        // GET: BrandsController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);

            return View(model);
        }

        // POST: BrandsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id,Brand brand , IFormFile? Logo)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    if (Logo is not null) brand.Logo = await FileHelper.FileLoaderAsync(Logo);

                    _service.Update(brand);
                    _service.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {

                    ModelState.AddModelError("", "Hata oluştu");

                }




            }

            return View(brand);
        }

        // GET: BrandsController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: BrandsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Brand brand)
        {
            try
            {
                _service.Delete(brand);
                _service.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                
            }

            return View();
        }
    }
}
