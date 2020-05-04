namespace UniversityManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEnrollCourseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnrollCourses", "EnrollDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.EnrollCourses", "CourseGrade", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EnrollCourses", "CourseGrade");
            DropColumn("dbo.EnrollCourses", "EnrollDate");
        }
    }
}
