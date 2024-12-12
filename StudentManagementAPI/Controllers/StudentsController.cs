using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;
using StudentManagementAPI.Repositories.Implementations;
using StudentManagementAPI.Repositories.Interfaces;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository context)
        {
            _studentRepository = context;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetStudent(int id)
        { 
            return Ok(_studentRepository.GetStudentById(id));
        }

        [HttpGet]       
        public IActionResult GetStudents()
        {
            try
            {
                var students = _studentRepository.GetStudents();
                return Ok(students);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] StudentHelper newStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _studentRepository.AddStudent(newStudent);
            return Ok("Student added successfully.");
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] StudentHelper updatedStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _studentRepository.UpdateStudent(id, updatedStudent);
                return Ok("Student updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                _studentRepository.DeleteStudent(id);
                return Ok("Student deleted successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
