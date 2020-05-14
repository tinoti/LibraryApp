namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReservationStatusToReservations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "ReservationStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reservations", "ReservationStatusId");
            AddForeignKey("dbo.Reservations", "ReservationStatusId", "dbo.ReservationStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "ReservationStatusId", "dbo.ReservationStatus");
            DropIndex("dbo.Reservations", new[] { "ReservationStatusId" });
            DropColumn("dbo.Reservations", "ReservationStatusId");
        }
    }
}
