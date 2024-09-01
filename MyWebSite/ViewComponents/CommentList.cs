using Microsoft.AspNetCore.Mvc;
using MyWebSite.Models;

namespace MyWebSite.ViewComponents
{
	public class CommentList:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var commentvalues = new List<UserComment>
			{
				new UserComment {
				ID = 1,
				Username = "Irem"
				},
				new UserComment {
				ID = 2,
				Username = "Sude"
				},
				new UserComment {
				ID = 3,
				Username = "Pelin"
				}
			};
			return View(commentvalues);
		}

	}
}
