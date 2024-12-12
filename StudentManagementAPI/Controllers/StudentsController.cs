using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;
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
        public async Task<IActionResult> GetStudent(int id)
        { 
            return Ok(await _studentRepository.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {            
            return Ok(await _studentRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student newStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _studentRepository.AddAsync(newStudent);
            return Ok("Student added successfully.");
        }

        [HttpPut]        
        public async Task<IActionResult> UpdateStudent([FromBody] Student updatedStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _studentRepository.UpdateAsync(updatedStudent);
                return Ok("Student updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                await _studentRepository.DeleteAsync(id);
                return Ok("Student deleted successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
