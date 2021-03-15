using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MoviesController()
        {
            _context = ApplicationDbContext.Create();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public ActionResult Index()
        {
            ApplicationUser applicationUser = new ApplicationUser()
            {

            };
            /** Eager Loading*/
            List<Movie> movies = _context.Movies.Include(m => m.Genre).ToList();

            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("Index");
            }

            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            Movie movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movie);
        }

        [HttpGet]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            List<Genre> genres = _context.Genres.ToList();
            MovieFormViewModel viewModel = new MovieFormViewModel()
            {
                Genre = genres
            };
            return View("MovieForm", viewModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult New(Movie movie)
        {
            List<Genre> genres = _context.Genres.ToList();
            MovieFormViewModel viewModel = new MovieFormViewModel(movie)
            {
                Genre = genres
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();
            //return View("MovieForm", viewModel);
            return View("Index", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies/*.Include("Genre")*/.Single(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            MovieFormViewModel viewModel = new MovieFormViewModel(movie)
            {
                Genre = _context.Genres.ToList()
            };
            return View("MoviesForm", viewModel);
            /**
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null) return HttpNotFound();
            var viewModel = new MovieFormViewModel(movie)
            {
                Genre = _context.Genre.ToList()
            };
            return View("MovieForm", viewModel);
            */
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (ModelState.IsValid == false)
            {
                MovieFormViewModel viewModel = new MovieFormViewModel(movie)
                {
                    Genre = _context.Genres.ToList()
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
            Movie movie = new Movie { Name = "Shrek!" };
            List<Customer> customers = new List<Customer>
            {new Customer { Name = "Customer 1", /*Id = 1*/ },new Customer { Name = "Customer 2", /*Id = 2 */},};

            RandomMovieViewModel viewModel = new RandomMovieViewModel
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