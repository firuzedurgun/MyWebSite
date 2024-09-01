using Microsoft.AspNetCore.Mvc;

namespace MyWebSite.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
