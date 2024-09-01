using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebSite.Areas.Admin.Models;

namespace MyWebSite.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    [Area("Admin")]
    public class ChartController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryname = "Technology",
                categorycount = 10
            });
            list.Add(new CategoryClass
            {
                categoryname = "Software",
                categorycount = 14
            });
            list.Add(new CategoryClass
            {
                categoryname = "Sport",
                categorycount = 5

            });
            list.Add(new CategoryClass
            {
                categoryname = "Cinema",
                categorycount = 4

            });
            return Json(new { jsonlist = list });
        }
    }
}
