using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int id);
        void AddStudent(StudentHelper student);
        void UpdateStudent(int id, StudentHelper student);
        void DeleteStudent(int id);
    }
}
