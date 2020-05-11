namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeRole : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO[dbo].[AspNetRoles]([Id], [Name]) VALUES(N'12f26872-6e7a-4a6f-a316-a21a321b25ef', N'Employee')");
        }
        
        public override void Down()
        {
        }
    }
}
