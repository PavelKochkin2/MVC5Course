namespace VidlyReborn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0c82a435-7421-4235-97d7-e036dfbec3c0', N'pashok@mail.com', 0, N'ACMTfQOWVKbaDJdEi7mjlN7u1AiEkHnZIA6EE9aKNtvosQqyQTk9OSxhl4TMS3UpmQ==', N'2502a0b1-8aa2-4e8a-ade4-09030ccca59e', NULL, 0, 0, NULL, 1, 0, N'pashok@mail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bc1a3538-3c3a-45f3-835b-86d27dd2b5da', N'admin@vidly.com', 0, N'AMzaePMkBkDkugV+kzahTHCwh5Lff2TmJkPN4xZhzQl2ga+6k/LxKPvwlxuxl+vvrg==', N'9c34648e-85b5-4d1b-9616-2859c4d6f515', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dae864a4-2148-4e5e-970e-6116fe0f04a7', N'guest@vidly.com', 0, N'AJgAmmJCailbg3OVjdNhuQtu6Mowo3KQp+j3YFlZL2mvYNhi765UyzZdTA6zTdd7zQ==', N'b3f9c99d-752d-41f5-b910-b09a5cd743c3', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'071da9f5-cb60-4a0c-bec4-4846da5b06c1', N'CanManageMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bc1a3538-3c3a-45f3-835b-86d27dd2b5da', N'071da9f5-cb60-4a0c-bec4-4846da5b06c1')
");
        }
        
        public override void Down()
        {
        }
    }
}
