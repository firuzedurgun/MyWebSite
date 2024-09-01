using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyWebSite.ViewComponents.Blog
{
	public class BlogLast3Post : ViewComponent
	{
		BlogManager bm = new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke()
		{
			var values = bm.GetLastThreeBlog();
			return View(values);
		}
	}
}
