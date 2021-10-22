using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Mywef.Models;

namespace Mywef.Controllers
{
    public class StudentController : Controller
    {
        string connectionString = @"data source=101.53.146.129;initial catalog=tipltrainee;user id=trainee;password=tipl#789;MultipleActiveResultSets=True;";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dts = new DataTable();
            using(SqlConnection sqlCon = new SqlConnection (connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Student_Trainee",sqlCon);
                sqlDa.Fill(dts);

            }
            return View(dts);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

       [HttpGet]
        public ActionResult Create()
        {
            return View(new StudentModel());
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel studentModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO Student_Trainee ([name],[lastname],[email],[gender],[dob]) VALUES(@name,@lastname,@email,@gender,@dob)";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
               // sqlcmd.Parameters.AddWithValue("@id",studentModel.id);
                sqlcmd.Parameters.AddWithValue("@name", studentModel.name);
                sqlcmd.Parameters.AddWithValue("@lastname", studentModel.lastname);
                sqlcmd.Parameters.AddWithValue("@email", studentModel.email);
                sqlcmd.Parameters.AddWithValue("@gender", studentModel.gender);
                sqlcmd.Parameters.AddWithValue("@dob", studentModel.dob);
                sqlcmd.ExecuteNonQuery();
            }
                return RedirectToAction("Index");
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            StudentModel studentModel = new StudentModel();
            DataTable dataTable = new DataTable();
            using(SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM Student_Trainee Where id = @id";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query,sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("id", id);
                sqlDa.Fill(dataTable);
            }
            if (dataTable.Rows.Count == 1)
            {
                studentModel.id = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                studentModel.name = (dataTable.Rows[0][1].ToString());
                studentModel.lastname = (dataTable.Rows[0][2].ToString());
                studentModel.email = (dataTable.Rows[0][3].ToString());
                studentModel.gender = (dataTable.Rows[0][4].ToString());
                studentModel.dob = Convert.ToDateTime(dataTable.Rows[0][5].ToString());
                return View(studentModel);
            }
            else
                return RedirectToAction("Index");
           
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(StudentModel studentModel)
        {

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE Student_Trainee SET name = @name, lastname = @lastname, email = @email, gender = @gender, dob= @dob Where id = @id";
              //  string query = "INSERT INTO Student_Trainee VALUES(@name,@email,@gender,@dob)";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                
                sqlcmd.Parameters.AddWithValue("@id", studentModel.id);
                sqlcmd.Parameters.AddWithValue("@name", studentModel.name);
                sqlcmd.Parameters.AddWithValue("@lastname", studentModel.lastname);
                sqlcmd.Parameters.AddWithValue("@email", studentModel.email);
                sqlcmd.Parameters.AddWithValue("@gender", studentModel.gender);
                sqlcmd.Parameters.AddWithValue("@dob", studentModel.dob);
                sqlcmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
            
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Student_Trainee  Where id = @id";
                //  string query = "INSERT INTO Student_Trainee VALUES(@name,@email,@gender,@dob)";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlcmd.Parameters.AddWithValue("@id", id);
                sqlcmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }



    }
}
