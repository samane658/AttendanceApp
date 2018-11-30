namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delayworkingAccountingInoutModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.inouts", "startTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.inouts", "endTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.rules", "startWorkTime", c => c.Double(nullable: false));
            AlterColumn("dbo.rules", "endWorkTime", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.rules", "endWorkTime", c => c.Int(nullable: false));
            AlterColumn("dbo.rules", "startWorkTime", c => c.Int(nullable: false));
            AlterColumn("dbo.inouts", "endTime", c => c.Int(nullable: false));
            AlterColumn("dbo.inouts", "startTime", c => c.Int(nullable: false));
        }
    }
}
