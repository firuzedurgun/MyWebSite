using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebSite.Models;

namespace MyWebSite.Controllers
{
	public class WriterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterRepository());
        [Authorize]
        public IActionResult Index()
		{
            var useremail = User.Identity.Name;
            ViewBag.v = useremail;
            Context c = new Context();
            var writername = c.Writers.Where(x => x.WriterEmail == useremail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writername;
			return View();
		}
        public IActionResult WriterProfile()
		{
			return View();
		}
		
		public IActionResult Test()
		{
			return View();
		}
        public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
		}
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
		[HttpGet]
		public IActionResult WriterEditProfile()
		{

            Context c = new Context();
            var useremail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterEmail == useremail).Select(y => y.WriterID).FirstOrDefault();
            var writervalues = wm.TGetById(writerID);
			return View(writervalues);
		}
		[HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
            var pas1 = Request.Form["pass1"];
            var pas2 = Request.Form["pass2"];
            if (pas1 == pas2)
            {
                p.WriterPassword = pas2;
                WriterValidator validationRules = new WriterValidator();
                ValidationResult result = validationRules.Validate(p);
                if (result.IsValid)
                {
                    wm.TUpdate(p);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else
            {
                ViewBag.error = "The passwords you entered do not match!";
            }
            return View();
        }
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();
            if(p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newimagename;
            }
            w.WriterEmail = p.WriterEmail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = "true";
            w.WriterAbout = p.WriterAbout;
            wm.TAdd(w);
            return RedirectToAction("Index","Dashboard");
        }



    }
}
