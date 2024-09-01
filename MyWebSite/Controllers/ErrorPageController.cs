using Microsoft.AspNetCore.Mvc;

namespace MyWebSite.Controllers
{
	public class ErrorPageController : Controller
	{
		public IActionResult Error1(int code)
		{
			return View();
		}
	}
}
