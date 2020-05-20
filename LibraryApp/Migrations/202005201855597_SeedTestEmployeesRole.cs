namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTestEmployeesRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Firstname], [Lastname]) VALUES (N'88757504-66e9-4761-9c84-b5dfe0e492f4', N'zaposlenik2@knjiznica.hr', 0, N'AKzaYGaxqETrZQRs2SxGjRGaA+Gr5WpX1ny3hK4fIHWu65qQpJnSQiJMgeVNTBPkDw==', N'14291ee7-1c01-43b6-a363-41a8e75ccf25', NULL, 0, 0, NULL, 1, 0, N'zaposlenik2@knjiznica.hr', N'Zaposlenik2', N'Zaposlenik2')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Firstname], [Lastname]) VALUES (N'e3bc3283-170e-4454-a472-c1d07b8e4480', N'zaposlenik1@knjiznica.hr', 0, N'AB84A+zEAkahwu97TeC88fnCMtbs6F4+KujQVD/8HP2kmqt5olXFOZ9f/7GZ6ZPX5A==', N'f7aeef05-0f3e-46cd-b92c-06f3c0d51709', NULL, 0, 0, NULL, 1, 0, N'zaposlenik1@knjiznica.hr', N'Zaposlenik1', N'Zaposlenik1')


            ");
        }
        
        public override void Down()
        {
        }
    }
}
