namespace AttendanceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userfieldToInoutadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.inouts", "user_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.inouts", "user_Id");
            AddForeignKey("dbo.inouts", "user_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.inouts", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.inouts", new[] { "user_Id" });
            DropColumn("dbo.inouts", "user_Id");
        }
    }
}
