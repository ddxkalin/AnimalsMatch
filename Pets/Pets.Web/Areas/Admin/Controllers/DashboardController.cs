namespace Pets.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
