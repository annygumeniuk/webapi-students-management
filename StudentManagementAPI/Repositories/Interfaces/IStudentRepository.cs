using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Repositories.Interfaces
{
    public interface IStudentRepository : IRepository<Student> {}
}
