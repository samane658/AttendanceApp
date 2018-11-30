namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iooutrestpersonidTypeChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.inouts", "personId", c => c.String());
            AlterColumn("dbo.rests", "personId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.rests", "personId", c => c.Int(nullable: false));
            AlterColumn("dbo.inouts", "personId", c => c.Int(nullable: false));
        }
    }
}
