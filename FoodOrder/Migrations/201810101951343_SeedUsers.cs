namespace FoodOrder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'27dc8731-50d4-4edf-ab3e-14ac97013669', N'guest@vidly.com', 0, N'AEhmVcct2aTvguuOvJcfy+t7S8sZNKHXZNBr9q7XKRxBFbwfEuuoybz0zONJiJDTUw==', N'4dfedf35-d1ee-4a33-8ac1-cd8b5cb02a73', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b7760d79-6e58-4499-88c6-0921992de11e', N'admin@vidly.com', 0, N'AFPcRtfuXSrt6V73+wTR3a94dfffeUtwh0it1Fp19xVYCvLcvO9bP1wfQy497sYHtA==', N'5fbe69b1-0a04-4314-8d31-a496fe732047', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'6a9441e7-587b-445f-9dfd-156568374487', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b7760d79-6e58-4499-88c6-0921992de11e', N'6a9441e7-587b-445f-9dfd-156568374487')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
