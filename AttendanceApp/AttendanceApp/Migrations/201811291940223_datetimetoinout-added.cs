namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimetoinoutadded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.inouts", "date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.inouts", "startTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.inouts", "endTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.inouts", "endTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.inouts", "startTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.inouts", "date", c => c.DateTime(nullable: false));
        }
    }
}
