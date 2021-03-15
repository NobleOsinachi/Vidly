using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create() => new ApplicationDbContext();


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Rental> Rentals { get; set; }
    }


    public class EmployeeService : IDisposable
    {
        public ApplicationDbContext _context { get; set; }
        public EmployeeService()
        {
            _context = ApplicationDbContext.Create();
        }
        public static EmployeeService Create()
        {
            return new EmployeeService();
        }

        public void Dispose()
        {//throw new NotImplementedException();
            return;
        }
    }
}
