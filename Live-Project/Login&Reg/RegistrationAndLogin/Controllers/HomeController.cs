using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RegistrationAndLogin.Models;
using System.Web.Mvc;


namespace RegistrationAndLogin.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            string mail = Session["Email"].ToString();
            using (MyModel dc = new MyModel())
            {
                return View(dc.UserMs.Where(x => x.Email == mail).FirstOrDefault());
            }
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}