using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Data
{
    public class ApplicationDbContext: DbContext
    {        
        // Creating a db sets of entities
        public DbSet<Student> Students { get; set; } // A
        public DbSet<Course>  Courses  { get; set; } // B
        public DbSet<Teacher> Teachers { get; set; } // C       

        // Configure the entity model and relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-many
            modelBuilder.Entity<Course>()
                .HasOne(s => s.Student)
                .WithMany(c => c.Courses)
                .HasForeignKey(f => f.StudentId);

            // One-to-one
            modelBuilder.Entity<Course>()
                .HasOne(t => t.Teacher)
                .WithOne(c => c.Course)
                .HasForeignKey<Teacher>(c => c.CourseId);
        }

        // Necessary for dependency injection to configure the db connection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
