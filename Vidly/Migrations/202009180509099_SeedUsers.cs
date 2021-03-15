namespace Vidly.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Vidly.Models;

    public partial class SeedUsers : DbMigration
    {
        #region DbContext
        private readonly ApplicationDbContext _context;
        public SeedUsers() => _context = ApplicationDbContext.Create();

        #endregion

        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'567ec25b-030c-4284-aa0f-6ec0f5a8baae', N'admin@vidly.com', 0, N'ADnWjN5E/meXNukxV5cyHMePZnalZG/oL1JazhZ74gBTU8JfM1pjDyZnAbUtRMPerA==', N'a14a4079-5f1e-4e55-8c12-d92e9fa40191', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'59a15607-d4a1-4360-b010-dc838e278b9a', N'nobleosinachi98@gmail.com', 0, N'APPfh7/ppqTa3PNkeFDkxNd7EBw2pm3zIrarUnQqCNNpZ5df0LeDqABipB6d+KWlIA==', N'82fc8775-94cb-4508-b7b7-154458739111', NULL, 0, 0, NULL, 1, 0, N'nobleosinachi98@gmail.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'68a68933-678c-4c5b-96be-a3e382716c77', N'guest@vidly.com', 0, N'ABSkEifWRczwOGnPbV9JMOW9uMwErynjyAjENrgWayLeyS9b7T2wEiszngQhvPbc4Q==', N'9fecbc02-ae79-4ad6-ad60-517840abc505', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'68a68933-678c-4c5b-96be-a3e382716c77', N'CanManageMovies')

            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'567ec25b-030c-4284-aa0f-6ec0f5a8baae', N'68a68933-678c-4c5b-96be-a3e382716c77')
            ");

            // Unknown PayAsYouGo Monthly Quaterly Yearly 

            Sql(@"
            INSERT INTO[dbo].[MembershipTypes] ([Id],[SignUpFee],[DurationInMonths],[DiscountRate]) VALUES(1, 00, 00, 00)
            INSERT INTO[dbo].[MembershipTypes] ([Id],[SignUpFee],[DurationInMonths],[DiscountRate]) VALUES(2, 30, 01, 10)
            INSERT INTO[dbo].[MembershipTypes] ([Id],[SignUpFee],[DurationInMonths],[DiscountRate]) VALUES(3, 90, 03, 15)
            INSERT INTO[dbo].[MembershipTypes] ([Id],[SignUpFee],[DurationInMonths],[DiscountRate]) VALUES(4, 300, 12, 20)
            ");

            //List<MembershipType> membershipType = new List<MembershipType>()
            //{
            //    new MembershipType{Id=1, Name="PayAsYouGo", SignUpFee=00, DurationInMonths=00, DiscountRate=00},
            //    new MembershipType{Id=2, Name="Monthly", SignUpFee=30, DurationInMonths=01, DiscountRate=10},
            //    new MembershipType{Id=3, Name="Quaterly", SignUpFee=00, DurationInMonths=03, DiscountRate=15},
            //    new MembershipType{Id=4, Name="Yearly", SignUpFee=00, DurationInMonths=12, DiscountRate=20}
            //};
            //membershipType.ForEach(m => _context.MembershipTypes.Add(m));
            //_context.SaveChanges();
            //_context.Dispose();

        }

        public override void Down()
        {
        }
    }
}
