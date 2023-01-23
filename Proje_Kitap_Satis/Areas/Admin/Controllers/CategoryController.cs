using Kitap.Entities;
using Kitap.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Proje_Kitap_Satis.Utils;

namespace Proje_Kitap_Satis.Areas.Admin.Controllers
{
    

    public class CategoryController : Controller
    {


        private readonly IService<Category> _service;

        public CategoryController(IService<Category> service)
        {
            _service = service;
        }



        // GET: CategoryController
        public ActionResult Index()
        {

            var model = _service.GetAll();

            return View(model);
        }



        // GET: CategoryController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            var model = await _service.FindAsync(id);

            return View(model);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Category category, IFormFile? Image)
        {
            if(ModelState.IsValid)

            {
                try
                {
                    category.Image = await FileHelper.FileLoaderAsync(Image);
                    _service.Add(category);
                    _service.SaveChanges();
                    


                    return RedirectToAction(nameof(Index));
                }
                catch
                {

                    ModelState.AddModelError("", "Hata Oluştu");
                    
                }

              


            }

            return View(category);


        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> EditAsync(int id)
        {
            var model = await _service.FindAsync(id);

            return View(model);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Category category , IFormFile? Image)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    if (Image is not null) category.Image = await FileHelper.FileLoaderAsync(Image);

                    _service.Update(category);
                    _service.SaveChanges();





                    return RedirectToAction(nameof(Index));
                }
                catch
                {

                    ModelState.AddModelError("", "Hata Olıştu");
                   
                }




            }
            return View(category);



        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);

            return View(model);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {

                _service.Delete(category);
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
