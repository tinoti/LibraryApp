namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedAdmin : DbMigration
    {
        public override void Up()
        {
            Sql(@"
              INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'702561a9-4b13-445f-8d25-9f9269fc4510', N'admin@knjiznica.hr', 0, N'ADYvVqXySec2cxZ9KEaZeZBReznp0KqX/V6sFqGol28a+Qugux/lQuX4shnuc/i3Yw==', N'f42557b0-70bc-4a4d-80d1-de43800855be', NULL, 0, 0, NULL, 1, 0, N'admin@knjiznica.hr')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd54133c6-c5fc-48f1-97e1-f89f1a230755', N'Admin')
  
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'702561a9-4b13-445f-8d25-9f9269fc4510', N'd54133c6-c5fc-48f1-97e1-f89f1a230755')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
