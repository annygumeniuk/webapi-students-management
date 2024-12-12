using StudentManagementAPI.Models;

namespace StudentManagementAPI.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
        Course GetCourseById(int id);
        void AddCourse(CourseHelper course);
        void UpdateCourse(int id, CourseHelper course);
        void DeleteCourse(int id);
    }
}
