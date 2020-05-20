namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBookGenres : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            SET IDENTITY_INSERT [dbo].[BookGenres] ON
            INSERT INTO [dbo].[BookGenres] ([Id], [Name]) VALUES (1, N'Romantizam')
            INSERT INTO [dbo].[BookGenres] ([Id], [Name]) VALUES (2, N'Drama')
            INSERT INTO [dbo].[BookGenres] ([Id], [Name]) VALUES (3, N'Horor')
            INSERT INTO [dbo].[BookGenres] ([Id], [Name]) VALUES (4, N'Znanstvena fantastika')
            INSERT INTO [dbo].[BookGenres] ([Id], [Name]) VALUES (1002, N'Kriminalistički')
            INSERT INTO [dbo].[BookGenres] ([Id], [Name]) VALUES (1003, N'Fantasy')
            SET IDENTITY_INSERT [dbo].[BookGenres] OFF
                
            ");
        }
        
        public override void Down()
        {
        }
    }
}
