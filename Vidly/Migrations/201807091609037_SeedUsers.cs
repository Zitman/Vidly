namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7e86f161-1dbf-4b39-9d78-8351baeb5cb4', N'guest@vidly.com', 0, N'AE5C+WLo3E3MlmFoRZ6QNPiUyd89Go5fGhoqhqxL2WdiVCx5VC/eHWKuUY75jXT5lA==', N'1368909e-9891-4840-a33a-565f4c4dea00', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8864c5ae-cce0-4f93-8b95-647630b624b6', N'admin@vidly.com', 0, N'AO7rt+jSh42JwasGB+1k97Oa9nb2zQVy7EUeNhFgDHMoV806orY8pY9sgQHVx/YtoA==', N'ebf8abae-607c-48ea-a92f-c76a0dc912c8', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
");
            Sql(@"
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e72e94c4-3a9a-45ec-b4d6-a45100738069', N'CanManageMovies')
");
            Sql(@"
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8864c5ae-cce0-4f93-8b95-647630b624b6', N'e72e94c4-3a9a-45ec-b4d6-a45100738069')
");
        }
        
        public override void Down()
        {
        }
    }
}
