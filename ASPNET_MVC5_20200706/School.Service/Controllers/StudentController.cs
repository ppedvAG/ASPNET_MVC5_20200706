using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using School.Domain.Entities;
using School.Service;

namespace School.Service.Controllers
{
    //MVC Basisklasse :Controller 
    public class StudentController : ApiController
    {
        private SchoolModel db = new SchoolModel();

        // GET: api/Student
        public IQueryable<Student> GetStudent()
        {
            //db.Student.Include(s => s.Standard).Include(s => s.StudentAddress);
            return db.Student;
        }

        // GET: api/Student/5
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> GetStudent(int id)
        {
            Student student = await db.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Student/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StudentID)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {

            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Student
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Student.Add(student);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = student.StudentID }, student);
        }

        // DELETE: api/Student/5
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> DeleteStudent(int id)
        {
            Student student = await db.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Student.Remove(student);
            await db.SaveChangesAsync();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Student.Count(e => e.StudentID == id) > 0;
        }
    }
}