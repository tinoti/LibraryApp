namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedReservationStatus : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            SET IDENTITY_INSERT [dbo].[ReservationStatus] ON
            INSERT INTO [dbo].[ReservationStatus] ([Id], [Name]) VALUES (1, N'Pending')
            INSERT INTO [dbo].[ReservationStatus] ([Id], [Name]) VALUES (2, N'Approved')
            INSERT INTO [dbo].[ReservationStatus] ([Id], [Name]) VALUES (3, N'Rejected')
            SET IDENTITY_INSERT [dbo].[ReservationStatus] OFF
            ");
        }
        
        public override void Down()
        {
        }
    }
}
