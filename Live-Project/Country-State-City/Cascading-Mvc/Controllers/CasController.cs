using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cascading_Mvc.Models;

namespace Cascading_Mvc.Controllers
{
    public class CasController : Controller
    {
        // GET: Cas
        public ActionResult Index()
        {
            SampleDBEntities sd = new SampleDBEntities();
            ViewBag.CountryList = new SelectList(GetCountryList(), "Cid", "Cname");
            return View();
        }

        public List<Country> GetCountryList()
        {
            SampleDBEntities sd = new SampleDBEntities();
            List<Country> countries = sd.Countries.ToList();
            return countries;
        }

        public ActionResult GetStateList(int Cid)
        {
            SampleDBEntities sd = new SampleDBEntities();
            List<State> SteteList = sd.States.Where(x => x.Cid == Cid).ToList();
            ViewBag.Slist = new SelectList(SteteList, "Sid", "Sname");
            return PartialView("DisplayStates");
        }

        public ActionResult GetCityList(int Sid)
        {
            SampleDBEntities sd = new SampleDBEntities();
            List<City> SteteList = sd.Cities.Where(x => x.Sid == Sid).ToList();
            ViewBag.Citylist = new SelectList(SteteList, "Cityid", "Cityname");
            return PartialView("DisplayCities");
        }
    }
}