using StudentManagementAPI.Data;
using StudentManagementAPI.Models;
using StudentManagementAPI.Repositories.Interfaces;

namespace StudentManagementAPI.Repositories.Implementations
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public void AddTeacher(TeacherHelper teacher)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeacher(int id)
        {
            throw new NotImplementedException();
        }

        public Teacher GetTeacherById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetTeachers()
        {
            throw new NotImplementedException();
        }

        public void UpdateTeacher(int id, TeacherHelper teacher)
        {
            throw new NotImplementedException();
        }
    }
}
