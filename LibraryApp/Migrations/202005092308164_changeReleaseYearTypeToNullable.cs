namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeReleaseYearTypeToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "ReleaseYear", c => c.DateTime());
        }
        
        public override void Down()
        {
        }
    }
}
