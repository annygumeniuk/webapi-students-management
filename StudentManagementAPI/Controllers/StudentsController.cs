using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models;
using StudentManagementAPI.Repositories.Interfaces;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : BaseController<Student>
    {
        public StudentsController(IRepository<Student> repository) : base(repository)
        {
        }        
    }
}
