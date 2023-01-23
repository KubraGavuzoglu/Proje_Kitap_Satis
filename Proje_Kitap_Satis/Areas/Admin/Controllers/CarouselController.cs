using Kitap.Entities;
using Kitap.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proje_Kitap_Satis.Utils;

namespace Proje_Kitap_Satis.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarouselController : Controller
    {
        private readonly IService<Carousel> _service;

        public CarouselController(IService<Carousel> service)
        {
            _service = service;
        }


        // GET: CarouselController
        public async Task<ActionResult> Index()
        {
           var model= await  _service.GetAllAsync();

            return View(model);
        }

        // GET: CarouselController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CarouselController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarouselController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Carousel carousel , IFormFile? Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(Image is not null) carousel.Image=await FileHelper.FileLoaderAsync(Image);
                    await _service.AddAsync(carousel);
                    await _service.SaveChangesAsync();



                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                    
                }




            }

            return View(carousel);

        }

        // GET: CarouselController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);


            return View(model);
        }

        // POST: CarouselController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Carousel carousel, IFormFile? Image)
        {
            if(ModelState.IsValid)
            {

                try
                {
                    if(Image is not null) carousel.Image= await FileHelper.FileLoaderAsync(Image);
                    _service.Update(carousel);
                    await _service.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu");
                }



            }
            return View(carousel);

        }

        // GET: CarouselController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarouselController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
