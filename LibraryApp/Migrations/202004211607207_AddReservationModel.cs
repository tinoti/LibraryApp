namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReservationModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Reservations", "BookId", "dbo.Books");
            DropIndex("dbo.Reservations", new[] { "MemberId" });
            DropIndex("dbo.Reservations", new[] { "BookId" });
            DropTable("dbo.Reservations");
        }
    }
}
