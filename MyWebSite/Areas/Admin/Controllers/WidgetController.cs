using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyWebSite.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    [Area("Admin")]
    public class WidgetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
