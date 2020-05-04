namespace UniversityManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyRegNo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "RegNo", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "RegNo", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
    }
}
