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
           this.PopMem(_context);
        }
        
        public override void Down()
        {
        }

        private void PopMem(ApplicationDbContext context)
        {
            //base.Seed(context);

            List<Genre> genre = new List<Genre>
            {                
                new Genre{Id=1, Name="Cartoon"},
            };
            genre.ForEach(e => context.Genres.Add(e));
            context.SaveChanges();
            context.Dispose();
        }        
    }
}