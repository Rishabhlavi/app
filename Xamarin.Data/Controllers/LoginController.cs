using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Xamarin.Data.Models;
using Xamarin.Data.Helpers;

namespace Xamarin.Data.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Username,Password")] XamarinLogin user)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            AmbassadorContext ctx = new AmbassadorContext();
            XamarinLogin attemp = ctx.Users.Where(x => x.Username == user.Username && x.Password == HashHelper.GenerateHashedPassword(user.Password)).FirstOrDefault();
            
            if (attemp == null)
                return RedirectToAction("Index","Login");

            FormsAuthentication.Initialize();
            FormsAuthentication.SetAuthCookie(user.Username, false);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}