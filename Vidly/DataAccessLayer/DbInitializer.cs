using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DataAccessLayer
{
    public class DbInitializer
    {
        #region DbContext
        private readonly ApplicationDbContext _context;
        public DbInitializer() => _context = new ApplicationDbContext();

        public DbInitializer(ApplicationDbContext context) => _context = context;
        #endregion

        public void PopulateGenre(ApplicationDbContext context)
        {
            List<Genre> genre = new List<Genre>
            {
                new Genre{Id=1, Name="Cartoon"},
                new Genre{Id=2, Name="Thriller"},
                new Genre{Id=3, Name="Romance"},
                new Genre{Id=4, Name="Family"},
            };
            genre.ForEach(g => context.Genres.Add(g));
            context.SaveChanges();
            context.Dispose();
        }
    }
}