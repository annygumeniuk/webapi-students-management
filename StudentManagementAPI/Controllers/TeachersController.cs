using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using StudentManagementAPI.Repositories.Interfaces;

namespace StudentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : BaseController<Teacher>
    {
        public TeachersController(IRepository<Teacher> repository) : base(repository) {}
    }
}
