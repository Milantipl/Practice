using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using regs.Models;
using PagedList;

namespace regs.Controllers
{
    public class RegController : Controller
    {
        // GET: Reg
        DbModel db = new DbModel();
        public ActionResult Index(int ? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 10;
            var Register = db.Registers.OrderBy(x => x.Id).ToPagedList(pageNumber, pageSize);
            return View(Register);
            
        }

        // GET: Reg/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reg/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reg/Create
        [HttpPost]
        public ActionResult Create(Register reg)
        {
            try
            {
               using(DbModel db=new DbModel())
                {
                    db.Registers.Add(reg);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reg/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reg/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reg/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reg/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
