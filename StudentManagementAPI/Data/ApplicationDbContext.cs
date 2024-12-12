using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Data
{
    public class ApplicationDbContext: DbContext
    {        
        // Creating a db sets of entities
        public DbSet<Student> Students { get; set; }
        public DbSet<Course>  Courses  { get; set; } 
        public DbSet<Teacher> Teachers { get; set; }      
        public DbSet<StudentCourse> StudentCourses { get; set; }

        // Configure the entity model and relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite key for StudentCourse
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            // Relationships
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId);
        }

        // Necessary for dependency injection to configure the db connection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
