using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Vidly.Models;

namespace Vidly.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Vidly.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {

        }

        private bool AddUserAndRole(ApplicationDbContext context)
        {
            RoleManager<IdentityRole> rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            IdentityResult ir = rm.Create(new IdentityRole("CanEdit"));
            UserManager<ApplicationUser> um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            ApplicationUser user = new ApplicationUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "nobleosinachi",
                Email = "noblechuks98@yahoo.com",
                EmailConfirmed = true,
                PasswordHash = "",
                AccessFailedCount = 1,
                LockoutEnabled = false,
                PhoneNumber = "+2349025778189",
                SecurityStamp = "084ADE59-EC70-4D61-90E8-FC82E5ECE167",
                LockoutEndDateUtc = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
            };
            ir = um.Create(user, "p@ssw0rd");
            if (ir.Succeeded == false)
            {
                return false;
            }

            return true;
        }

        private static void PopulateMembershipType(ApplicationDbContext context)
        {
            // Unknown PayAsYouGo Monthly Quaterly Yearly 

            List<MembershipType> membershipType = new List<MembershipType>()
            {
                new MembershipType{Id=1, Name="PayAsYouGo", SignUpFee=00, DurationInMonths=00, DiscountRate=00},
                new MembershipType{Id=2, Name="Monthly", SignUpFee=30, DurationInMonths=01, DiscountRate=10},
                new MembershipType{Id=3, Name="Quaterly", SignUpFee=00, DurationInMonths=03, DiscountRate=15},
                new MembershipType{Id=4, Name="Yearly", SignUpFee=00, DurationInMonths=12, DiscountRate=20}
            };
            membershipType.ForEach(m => context.MembershipTypes.Add(m));
            context.SaveChanges();
        }
    }
}
