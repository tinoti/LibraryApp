namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTestBooks : DbMigration
    {
        public override void Up()
        {
            Sql(@"

            SET IDENTITY_INSERT [dbo].[Books] ON
            INSERT INTO [dbo].[Books] ([Id], [Name], [ReleaseYear], [NumberInStock], [NumberAvailable], [BookGenreId], [Description], [Author]) VALUES (2019, N'1984.', N'1949-08-06 00:00:00', 10, 10, 4, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum', N'George Orwell')
            INSERT INTO [dbo].[Books] ([Id], [Name], [ReleaseYear], [NumberInStock], [NumberAvailable], [BookGenreId], [Description], [Author]) VALUES (2020, N'Harry Potter and the Philosopher''s Stone', N'1997-06-26 00:00:00', 5, 5, 1003, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum', N'J. K. Rowling')
            INSERT INTO [dbo].[Books] ([Id], [Name], [ReleaseYear], [NumberInStock], [NumberAvailable], [BookGenreId], [Description], [Author]) VALUES (2021, N'Harry Potter and the Chamber of Secrets', N'1998-07-02 00:00:00', 7, 7, 1003, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum', N'J. K. Rowling')
            INSERT INTO [dbo].[Books] ([Id], [Name], [ReleaseYear], [NumberInStock], [NumberAvailable], [BookGenreId], [Description], [Author]) VALUES (2022, N'A Song of Ice and Fire', N'1996-07-01 00:00:00', 8, 8, 1003, N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum', N'George R. R. Martin')
            INSERT INTO [dbo].[Books] ([Id], [Name], [ReleaseYear], [NumberInStock], [NumberAvailable], [BookGenreId], [Description], [Author]) VALUES (2023, N'Test nedostupna knjiga', N'2000-01-01 00:00:00', 10, 0, 2, NULL, N'Test')
            INSERT INTO [dbo].[Books] ([Id], [Name], [ReleaseYear], [NumberInStock], [NumberAvailable], [BookGenreId], [Description], [Author]) VALUES (2024, N'Test Knjiga', N'2000-01-01 00:00:00', 15, 15, 1002, NULL, N'Test')
            SET IDENTITY_INSERT [dbo].[Books] OFF
            ");
        }
        
        public override void Down()
        {
        }
    }
}
