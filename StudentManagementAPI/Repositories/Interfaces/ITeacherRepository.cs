using StudentManagementAPI.Models;

namespace StudentManagementAPI.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetTeachers();
        Teacher GetTeacherById(int id);
        void AddTeacher(TeacherHelper teacher);
        void UpdateTeacher(int id, TeacherHelper teacher);
        void DeleteTeacher(int id);
    }
}
