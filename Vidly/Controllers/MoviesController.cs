using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MoviesController() => _context = new ApplicationDbContext();
        protected override void Dispose(bool disposing) => _context.Dispose();

        [HttpGet]
        public ActionResult Index()
        {
            List<Movie> movies = _context.Movies.Include("Genre").ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            _context.Movies.Include("Genre").SingleOrDefault(m => m.Id == id);
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {

            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);


        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult New(Movie movie)
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = genres
            };
            try
            {
                using (_context)
                {
                    _context.Movies.Add(movie);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies/*.Include("Genres")*/.Single(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MoviesForm", viewModel);
            /**
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null) return HttpNotFound();
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
    */
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                Movie movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            _context.Dispose();
            return RedirectToAction("Index", "Movies");
        }


        public ActionResult Random()
        {
            var movie = new Movie { Name = "Shrek!" };
            var customers = new List<Customer>
            {new Customer { Name = "Customer 1", Id = 1 },new Customer { Name = "Customer 2", Id = 2 },};

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return Content(content: @"<div>&#9776;</div><h1>RANDOM CONTROLLER</h1>"
                          //,contentType: "UTF-8"
                          //,contentEncoding:Encoding.UTF8
                          );
        }

        [Route("Movies/ReleaseDate/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(01,12)}")]
        public ActionResult ReleaseDate(int? year, byte? month)
        {
            return Content(year + "/" + month);
        }
    }
}