using StudentManagementAPI.Models;
using StudentManagementAPI.Data;
using StudentManagementAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementAPI.Repositories.Implementations
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }        
    }
}
