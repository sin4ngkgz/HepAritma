using ETicaret.Web.Code.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Web.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [AuthActionFilter(Role ="Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult Role() => View();

        public IActionResult Product() => View();

        public IActionResult Category() => View();  

        public IActionResult Customer() => View();
    }
}
