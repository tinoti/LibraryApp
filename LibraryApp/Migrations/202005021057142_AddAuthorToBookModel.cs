namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthorToBookModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Author", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Author");
        }
    }
}
