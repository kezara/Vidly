namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9826befe-9a4a-4783-aa8e-7903e66939f5', N'guest@vidly.com', 0, N'AD74yI3mPisfFbrIss5XSr/roSyN6XFjKba8Zs6BpSqUrRcxeenQYeUra6IuE+aarw==', N'895df330-cedb-47d3-a11b-54837507612e', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ad2e67df-c4ee-4b3a-ac46-c8ed2defda7f', N'admin@vidly.com', 0, N'AKERWFDk/1IQmglbLxHbRkYMtyBQ4cW09FUmah7pgwhHzS7xVAon1cws4YFwTjKHuw==', N'6d79ca20-18e4-4675-ac64-6cd606f3c6e1', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f9522f4e-77a8-49a9-a3a5-2b490fa1b0cf', N'CanManageMovies')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ad2e67df-c4ee-4b3a-ac46-c8ed2defda7f', N'f9522f4e-77a8-49a9-a3a5-2b490fa1b0cf')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
