using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using MyFirst.Models;

namespace MyFirst.Controllers
{
    public class ResultController : Controller
    {
        // GET: Result
        public ActionResult Index()
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.student_result.ToList());
            }

        }

        // GET: Result/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.student_result.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // GET: Result/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Result/Create
        [HttpPost]
        public ActionResult Create(student_result student_Result)
        {
            try
            {
                using (DbModels dbModels = new DbModels())
                {
                    dbModels.student_result.Add(student_Result);
                    dbModels.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Result/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.student_result.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, student_result student_Result)
        {
            try
            {
                using (DbModels dbModels = new DbModels())
                {
                    dbModels.Entry(student_Result).State = EntityState.Modified;
                    dbModels.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Result/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.student_result.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try

            {
                // TODO: Add delete logic here
                using (DbModels dbModels = new DbModels())
                {
                    student_result student_Result  = dbModels.student_result.Where(x => x.id == id).FirstOrDefault();
                    dbModels.student_result.Remove(student_Result);
                    dbModels.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
