using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using UniversityManagement.Models;

namespace UniversityManagement.DataContext
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassSchedule> ClassSchedules { get; set; }
        public DbSet<CourseAssign> CourseAssigns { get; set; }
        public DbSet<EnrollCourse> EnrollCourses { get; set; }
        public DbSet<RoomAllocation> RoomAllocations { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

    }
}