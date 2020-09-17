namespace Vidly.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Vidly.Models;

    public partial class PopulateMembershipTypes : DbMigration
    {

        #region DbContext
        private readonly ApplicationDbContext _context;
        public PopulateMembershipTypes() => _context = new ApplicationDbContext();
        #endregion

        public override void Up()
        {
            // Unknown PayAsYouGo Monthly Quaterly Yearly 

            Sql("INSERT INTO[dbo].[MembershipTypes] ([Id],[SignUpFee],[DurationInMonths],[DiscountRate]) VALUES(1, 00, 00, 00)");
            Sql("INSERT INTO[dbo].[MembershipTypes] ([Id],[SignUpFee],[DurationInMonths],[DiscountRate]) VALUES(2, 30, 01, 10)");
            Sql("INSERT INTO[dbo].[MembershipTypes] ([Id],[SignUpFee],[DurationInMonths],[DiscountRate]) VALUES(3, 90, 03, 15)");
            Sql("INSERT INTO[dbo].[MembershipTypes] ([Id],[SignUpFee],[DurationInMonths],[DiscountRate]) VALUES(4, 300, 12, 20)");

            List<MembershipType> membershipType = new List<MembershipType>()
            {
                new MembershipType{Id=1, Name="PayAsYouGo", SignUpFee=00, DurationInMonths=00, DiscountRate=00},
                new MembershipType{Id=2, Name="Monthly", SignUpFee=30, DurationInMonths=01, DiscountRate=10},
                new MembershipType{Id=3, Name="Quaterly", SignUpFee=00, DurationInMonths=03, DiscountRate=15},
                new MembershipType{Id=4, Name="Yearly", SignUpFee=00, DurationInMonths=12, DiscountRate=20}
            };
            membershipType.ForEach(m => _context.MembershipTypes.Add(m));
            _context.SaveChanges();
            _context.Dispose();
        }

        public override void Down()
        {
        }
    }
}
