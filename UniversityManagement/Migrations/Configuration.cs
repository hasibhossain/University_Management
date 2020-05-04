namespace UniversityManagement.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UniversityManagement.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityManagement.DataContext.UniversityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UniversityManagement.DataContext.UniversityDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //context.Semesters.AddOrUpdate(

            //    new Semester() { Name = "1st Semester" },
            //    new Semester() { Name = "2nd Semester" },
            //    new Semester() { Name = "3rd Semester" },
            //    new Semester() { Name = "4th Semester" },
            //    new Semester() { Name = "5th Semester" },
            //    new Semester() { Name = "6th Semester" },
            //    new Semester() { Name = "7th Semester" },
            //    new Semester() { Name = "8th Semester" }

            //    );

            //context.Grades.AddOrUpdate(

            //  new Grade() { Name = "A+" },
            //  new Grade() { Name = "A" },
            //  new Grade() { Name = "A-" },
            //  new Grade() { Name = "B+" },
            //  new Grade() { Name = "B" },
            //  new Grade() { Name = "B-" },
            //  new Grade() { Name = "C+" },
            //  new Grade() { Name = "C" },
            //  new Grade() { Name = "C-" },
            //  new Grade() { Name = "D+" },
            //  new Grade() { Name = "D" },
            //  new Grade() { Name = "D-" },
            //  new Grade() { Name = "F" }

            //  );
            //context.Days.AddOrUpdate(
            //    new Day() { Name = "Saturday" },
            //    new Day() { Name = "Sunday" },
            //    new Day() { Name = "Monday" },
            //    new Day() { Name = "Tuesday" },
            //    new Day() { Name = "Wednesday" },
            //    new Day() { Name = "Thursday" }
            //    );

            //context.Designations.AddOrUpdate(

            //  new Designation() { Name = "Professor" },
            //  new Designation() { Name = "Associate Professor" },
            //  new Designation() { Name = "Assistent Professor" },
            //  new Designation() { Name = "Lecturer" },
            //  new Designation() { Name = "Instructor" }

            //  );

            //context.Rooms.AddOrUpdate(

            //    new Room() { Name = "101" },
            //    new Room() { Name = "102" },
            //    new Room() { Name = "201" },
            //    new Room() { Name = "202" },
            //    new Room() { Name = "301" },
            //    new Room() { Name = "302" },
            //    new Room() { Name = "401" },
            //    new Room() { Name = "402" },
            //    new Room() { Name = "501" },
            //    new Room() { Name = "502" }
            //    );
        }
    }
}
