using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.Web.Security;
using Shopping.Models;


namespace Shopping.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")] User user)
    {
        return View(user);
    }
}