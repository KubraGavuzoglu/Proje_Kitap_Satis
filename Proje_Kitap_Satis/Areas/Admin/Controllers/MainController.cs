using Microsoft.AspNetCore.Mvc;

namespace Proje_Kitap_Satis.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
