using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using School.Domain.Entities;

namespace School.MVC.Controllers
{
    //Zuätzliches Beispeil Await /Async Pattern
    public class StudentController : Controller
    {
        

        // GET: Student
        public async Task<ActionResult> Index()
        {

            List<Student> studentList = null;

            string url = "https://localhost:44390/api/Student";


            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    studentList = JsonConvert.DeserializeObject<List<Student>>(apiResponse);
                }
            }

            if (studentList == null)
            {
                return HttpNotFound();
            }

            return View(studentList);
        }

        // GET: Student/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Student student = null;

            string url = "https://localhost:44390/api/Student/" + id.Value;
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View(new Student());
        }

        // POST: Student/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentID,FirstName,StandardId,RowVersion,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(student);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "https://localhost:44390/api/Student";

                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync(url, data);
                    string result = response.Content.ReadAsStringAsync().Result;
                    return RedirectToAction(nameof(Index));
                } 
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Student student = null;

            string url = "https://localhost:44390/api/Student/" + id.Value;
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }


            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StudentID,FirstName,StandardId,RowVersion,LastName")] Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(student);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var url = "https://localhost:44390/api/Student/" + student.StudentID;
                    using (var client = new HttpClient())
                    {
                        var response = await client.PutAsync(url, data);
                        string result = response.Content.ReadAsStringAsync().Result;
                    }
                }
                catch (Exception ex)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Student student  = null;

            string url = "https://localhost:44390/api/Student/" + id.Value;
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }

            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var url = "https://localhost:44390/api/Student/" + id;
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync(url);
                string result = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction(nameof(Index));
            }
        }

        
    }
}
