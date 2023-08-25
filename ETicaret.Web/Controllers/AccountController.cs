using ETicaret.Web.Code;
using ETicaret.Web.Code.Rest;
using ETicaret.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace ETicaret.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login() => View();

        public IActionResult GirisYap(LoginModel model)
        {
            UserRestClient client = new UserRestClient();
            dynamic result = client.Login(model.Email, model.Password);

            bool success = result.success;

            if (success) 
            {
                Repo.Session.Email = model.Email;
                Repo.Session.Token = (string)result.data;
                Repo.Session.Role = (string)result.role;

                if (Repo.Session.Role=="Admin") 
                {
                    return RedirectToAction("Index", "Home" , new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }
            else
            {
                ViewBag.LoginError = (string)result.message;
                return View("Login");
            }

        }

        public IActionResult SignUp() => View();

        public IActionResult Kaydol(SignUpModel model)
        {
            UserRestClient client = new UserRestClient();
            dynamic result = client.SignUp(model.FirstName, model.LastName, model.PhoneNumber, model.Email, model.Password);

            bool success = result.success;

            if (success)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.SignUpError = (string)result.message;
                return View("SignUp");
            }
        }

        

        public IActionResult Logout()
        {
            Repo.Session.Email ="";
            Repo.Session.Token ="";
            Repo.Session.Role ="";

            return RedirectToAction("Index", "Home" );
        }
    }

}
