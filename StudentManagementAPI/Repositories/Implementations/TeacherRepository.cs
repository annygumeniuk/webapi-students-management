using StudentManagementAPI.Data;
using StudentManagementAPI.Models;
using StudentManagementAPI.Repositories.Interfaces;

namespace StudentManagementAPI.Repositories.Implementations
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }        
    }
}
