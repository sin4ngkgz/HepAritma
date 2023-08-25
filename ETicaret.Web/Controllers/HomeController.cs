using ETicaret.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ETicaret.Web.Controllers
{
    public class HomeController : Controller
    {

        public HomeController() { }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KategoriEvselSu()
        {
            return View();
        }

        public IActionResult KategoriEvselYedek()
        {
            return View();
        }
        public IActionResult KategoriEndüstrielSu()
        {
            return View();
        }
        public IActionResult KategoriEndüstrielYedek()
        {
            return View();
        }
        public IActionResult AquaMabSu()
        {
            return View();
        }
        public IActionResult FobriteT15()
        {
            return View();
        }
        public IActionResult VigorSuArıtma()
        {
            return View();
        }
        public IActionResult RunxınF7P1()
        {
            return View();
        }
        public IActionResult GalonTank()
        {
            return View();
        }
        public IActionResult EkoApex()
        {
            return View();
        }
        public IActionResult OnArıtmalıRo900()
        {
            return View();
        }
        public IActionResult AquaMabRo300()
        {
            return View();
        }
        public IActionResult HatAlma()
        {
            return View();
        }
        public IActionResult AquaBirRo400()
        {
            return View();
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}