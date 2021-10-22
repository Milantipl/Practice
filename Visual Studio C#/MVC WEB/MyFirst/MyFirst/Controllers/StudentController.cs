using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MyFirst.Models;

namespace MyFirst.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using(DbModels dbModels = new DbModels())
            {
                return View(dbModels.Student_Trainee1.ToList());
            }
            
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            using(DbModels dbModels = new DbModels())
            {
                return View(dbModels.Student_Trainee1.Where(x => x.id ==id).FirstOrDefault());
            }
            
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student_Trainee1 student_Trainee1)
        {
            try
            {
                using (DbModels dbModels = new DbModels())
                {
                    dbModels.Student_Trainee1.Add(student_Trainee1);
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

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.Student_Trainee1.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student_Trainee1 student_Trainee1)
        {
            try
            {
                using(DbModels dbModels = new DbModels())
                {
                    dbModels.Entry(student_Trainee1).State = EntityState.Modified;
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModels = new DbModels())
            {
                return View(dbModels.Student_Trainee1.Where(x => x.id == id).FirstOrDefault());
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
                    Student_Trainee1 student_Trainee1 = dbModels.Student_Trainee1.Where(x => x.id == id).FirstOrDefault();
                    dbModels.Student_Trainee1.Remove(student_Trainee1);
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
