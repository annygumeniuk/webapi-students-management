using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {                                  
            return Ok(_context.Students.ToList());           
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStudent(int id)
        {
            return Ok(_context.Students.Where(s => s.Id == id).ToList());
        }

        [HttpPost]
        public IActionResult AddStudent(StudentCreateModel newStudent)
        {
            var student = new Student()
            { 
                Name = newStudent.Name,
                Email = newStudent.Email,
                Password = newStudent.Password,
                Courses = newStudent.Courses,
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return Ok(student);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateStudent(int id, StudentCreateModel student)
        { 
            var studentToChange = (Student)_context.Students.FirstOrDefault(s => s.Id == id);
            if (studentToChange != null)
            {
                studentToChange.Name     = student.Name;
                studentToChange.Email    = student.Email;
                studentToChange.Password = student.Password;
                studentToChange.Courses  = student.Courses;
                _context.SaveChanges();
                return Ok(studentToChange);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteStudent(int id)
        {                        
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return Ok();                                    
        }        
    }
}
