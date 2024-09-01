using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using X.Web.PagedList;
using X.PagedList.Extensions;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MyWebSite.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    [Area("Admin")]

    public class CategoryController : Controller
    {
      
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var values = cm.GetList().ToPagedList(page, 3);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {

                p.CategoryStatus = true;
                cm.TAdd(p);
                return RedirectToAction("Index", "Category");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }
         public IActionResult CategoryDelete(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
