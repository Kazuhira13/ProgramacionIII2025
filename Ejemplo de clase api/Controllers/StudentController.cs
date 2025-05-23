using Clase11.Data;
using Clase11.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;
using System.Security.Claims;

namespace Clase11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private ClaseDbContext _context;
        public StudentController(ClaseDbContext context) { 
            _context = context;
        }

        [HttpGet]
        public List<Student> GetStudents()
        {
            var userId = User?.Claims.Where(s => s.Type == "user_id").FirstOrDefault();
            var students = _context.Students.Where(s => s.CreatedBy == userId.Value);
            return students.ToList();
        }

        [HttpPost]
        public Student Create([FromBody]Student student) { 
            var savedStudent = _context.Students.Add(student);
            _context.SaveChanges();
            return savedStudent.Entity;
        }

        [HttpGet("{id}")]
        public Student GetStudent(int id) {

            var userName = User?.Claims.Where(s=> s.Type == "name").FirstOrDefault();

            var student = _context.Students.Where(s=> s.Id == id).SingleOrDefault();
            Response.Headers.Add("userName", userName.Value);
            return student;
        }

        [HttpPut("{id}")]
        public Student Update([FromRoute] int id, [FromBody]Student updated)
        {
            var student = _context.Students.Where(s => s.Id == id).SingleOrDefault();
            if (student != null) { 
                student.Email = updated.Email;
                student.FirstName = updated.FirstName;
                student.LastName = updated.LastName;
                student.Phone = updated.Phone;
                student.CreatedBy = updated.CreatedBy;
                _context.SaveChanges();
            }

            return student;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var student = _context.Students.Where(s => s.Id == id).SingleOrDefault();
            if (student != null) { 
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return NoContent();
        }

    }
}
