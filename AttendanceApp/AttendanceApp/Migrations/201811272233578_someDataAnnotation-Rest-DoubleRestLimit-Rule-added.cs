namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someDataAnnotationRestDoubleRestLimitRuleadded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.rules", "restLimit", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.rules", "restLimit", c => c.Int(nullable: false));
        }
    }
}
