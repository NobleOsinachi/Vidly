using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Vidly.Models;

namespace Vidly.DataAccessLayer
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //base.Seed(context);
            //Seed(context);

            List<Genre> genre = new List<Genre>
{

new Genre{ Id=0, Name="Unknown"},
new Genre{ Name="Action"},
new Genre{ Name="Adventure" },
new Genre{ Name="Animation" },
new Genre{ Name="Children" },
new Genre{ Name="Comedy" },
new Genre{ Name="Crime" },
new Genre{ Name="Documentary" },
new Genre{ Name="Drama" },
new Genre{ Name="Family" },
new Genre{ Name="Fiction" },
new Genre{ Name="Fantasy" },
new Genre{ Name="FilmNoir" },
new Genre{ Name="Horror" },
new Genre{ Name="Love" },
new Genre{ Name="Musical" },
new Genre{ Name="Mystery" },
new Genre{ Name="NonFiction" },
new Genre{ Name="Romance" },
new Genre{ Name="SciFi" },
new Genre{ Name="Thriller" },
new Genre{ Name="War" },
new Genre{ Name="Western" },
};
            genre.ForEach(g => context.Genres.Add(g));
            context.SaveChanges();


            List<Movie> movies = new List<Movie> {
new Movie{Name="", DateAdded=DateTime.Now, NumberAvailable=12, NumberInStock=12,}
};
            movies.ForEach(m => context.Movies.Add(m));
            context.SaveChanges();






        }
    }
}
