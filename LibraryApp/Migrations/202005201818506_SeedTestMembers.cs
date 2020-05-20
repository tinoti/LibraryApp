namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTestMembers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

            SET IDENTITY_INSERT [dbo].[Members] ON
            INSERT INTO [dbo].[Members] ([Id], [Name], [MembershipCardNumber], [Email], [BirthDate], [DateOfJoining]) VALUES (1, N'Member1', N'1', N'test@gmail.com', N'1990-01-01 00:00:00', N'2020-01-01 00:00:00')
            INSERT INTO [dbo].[Members] ([Id], [Name], [MembershipCardNumber], [Email], [BirthDate], [DateOfJoining]) VALUES (2, N'Member2', N'2', N'test2@gmail.com', N'1990-01-01 00:00:00', N'2020-01-01 00:00:00')
            SET IDENTITY_INSERT [dbo].[Members] OFF

            ");
        }
        
        public override void Down()
        {
        }
    }
}
