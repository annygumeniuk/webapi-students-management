using StudentManagementAPI.Models;
using StudentManagementAPI.Data;
using StudentManagementAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementAPI.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetStudents()
        {            
            return _context.Students.ToList();            
        }

        public Student GetStudentById(int id)
        {
            return (Student)_context.Students.Where(s => s.Id == id);
        }

        public void AddStudent(StudentHelper newStudent)
        {
            var student = new Student()
            {
                Name = newStudent.Name,
                Email = newStudent.Email,
                Password = newStudent.Password,
                Courses = newStudent.Courses,
            };

            _context.Students.Add(student);
            _context.SaveChanges();            
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            
            if (student == null)
            {
                throw new KeyNotFoundException($"No student found with ID {id}");
            }

            _context.Students.Remove(student);
            _context.SaveChanges();            
        }

        public void UpdateStudent(int id, StudentHelper student)
        {
            var studentToChange = _context.Students.FirstOrDefault(s => s.Id == id);

            if (studentToChange == null)
            {
                throw new KeyNotFoundException($"No student found with ID {id}");
            }

            studentToChange.Name = student.Name;
            studentToChange.Email = student.Email;
            studentToChange.Password = student.Password;
            studentToChange.Courses = student.Courses;
            _context.SaveChanges();                                     
        }
    }
}
