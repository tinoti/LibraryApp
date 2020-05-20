namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReservationTimeToReservationModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "ReservationTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "ReservationTime");
        }
    }
}
