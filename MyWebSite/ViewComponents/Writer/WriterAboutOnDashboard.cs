using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyWebSite.ViewComponents.Writer
{
   
    public class WriterAboutOnDashboard : ViewComponent
    {
        WriterManager writermanager = new WriterManager(new EfWriterRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var useremail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterEmail == useremail).Select(y => y.WriterID).FirstOrDefault();
            var values = writermanager.GetWriterById(writerID);
            return View(values);
        }
    }
}
