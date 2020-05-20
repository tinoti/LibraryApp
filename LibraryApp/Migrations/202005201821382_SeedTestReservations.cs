namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTestReservations : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            SET IDENTITY_INSERT [dbo].[Reservations] ON
            INSERT INTO [dbo].[Reservations] ([Id], [BookId], [MemberId], [ReservationStatusId], [ReservationTime]) VALUES (3153, 2019, 1, 2, N'2020-05-20 20:20:55')
            INSERT INTO [dbo].[Reservations] ([Id], [BookId], [MemberId], [ReservationStatusId], [ReservationTime]) VALUES (3154, 2022, 1, 3, N'2020-05-20 20:20:55')
            INSERT INTO [dbo].[Reservations] ([Id], [BookId], [MemberId], [ReservationStatusId], [ReservationTime]) VALUES (3155, 2021, 1, 1, N'2020-05-20 20:20:55')
            SET IDENTITY_INSERT [dbo].[Reservations] OFF

            ");
        }
        
        public override void Down()
        {
        }
    }
}
