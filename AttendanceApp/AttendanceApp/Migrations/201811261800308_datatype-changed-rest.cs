namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatypechangedrest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.rests", "startTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.rests", "endTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.rests", "endTime", c => c.Int(nullable: false));
            AlterColumn("dbo.rests", "startTime", c => c.Int(nullable: false));
        }
    }
}
