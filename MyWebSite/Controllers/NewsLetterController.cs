using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MyWebSite.Controllers
{
	public class NewsLetterController : Controller
	{
		NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());	
		[HttpGet]
		public PartialViewResult SubscribeEmail()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult SubscribeEmail(NewsLetter p)
		{
			p.EmailStatus = true;
			nm.AddNewsLetter(p);
			return PartialView();
		}
	}
}
