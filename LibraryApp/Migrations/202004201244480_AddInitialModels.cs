namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ReleaseYear = c.DateTime(nullable: false),
                        NumberInStock = c.Int(nullable: false),
                        NumberAvailable = c.Int(nullable: false),
                        BookGenreId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookGenres", t => t.BookGenreId, cascadeDelete: true)
                .Index(t => t.BookGenreId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MembershipCardNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        DateOfJoining = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "BookGenreId", "dbo.BookGenres");
            DropIndex("dbo.Books", new[] { "BookGenreId" });
            DropTable("dbo.Members");
            DropTable("dbo.Books");
            DropTable("dbo.BookGenres");
        }
    }
}
