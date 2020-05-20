namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTestEmployees : DbMigration
    {
        public override void Up()
        {
            Sql(@"

            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Firstname], [Lastname]) VALUES (N'0d0c80ca-e021-488a-9b91-f2ee27bb65ef', N'zaposlenik2@knjiznica.hr', 0, N'AP50TjSb1s21EhGEuiTM4EZTZQufQjIGmxI0z2xsvcgeKrxSeoc5BDDH3M2AuRcNFw==', N'dac82067-3bd0-4be8-99e9-91b25b71832b', NULL, 0, 0, NULL, 1, 0, N'zaposlenik2@knjiznica.hr', N'Zaposlenik2', N'Zaposlenik2')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Firstname], [Lastname]) VALUES (N'e5c96cbf-c04c-47ef-af83-ff03a99c597a', N'zaposlenik1@knjiznica.hr', 0, N'AAfwQJGFArv3X8mhChfVbc/hziS4CLY/6cbca/fQ0UBnbDk9gYtZ4TdmRTrO9iONRw==', N'11e5f552-dcb9-4f33-8f90-39f18b6beefc', NULL, 0, 0, NULL, 1, 0, N'zaposlenik1@knjiznica.hr', N'Zaposlenik1', N'Zaposlenik1')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
