using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MAdminAuth.Models;
using System.Web.Security;

namespace MAdminAuth.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin_Milan model, string returnUrl)
        {
            MyAdminEntities db = new MyAdminEntities();

            var dataItem = db.Admin_Milan.Where(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefault();
            if (dataItem != null)
            {
                FormsAuthentication.SetAuthCookie(dataItem.Username, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        
            else
            {
                ModelState.AddModelError("", "Invalid User/Pass");
                return View();
            }
        }
        [Authorize]
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

    }
}