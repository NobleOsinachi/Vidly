using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public NewRentalsController() => _context = ApplicationDbContext.Create();
        protected override void Dispose(bool disposing) => _context.Dispose();

        //POST /api/NewRentals
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            /**Edge cases 
             * CustomerId is invalid
             * No MovieIds
             * One or more MovieIds are invalid
             * One or more Movies are not available
             */
            try
            {

                if (string.IsNullOrWhiteSpace(newRental.ToString()))
                    return BadRequest("Request can not be empty.");

                Customer customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);
                if (customer == null || newRental.CustomerId == 0 || string.IsNullOrWhiteSpace(newRental.CustomerId.ToString()))
                    return BadRequest("CustomerId is not valid");

                if (newRental.MovieIds.Count == 0 || newRental.MovieIds == null)
                    return BadRequest("No MovieIds have been given");

                List<Movie> movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

                if (movies.Count != newRental.MovieIds.Count)
                    return BadRequest("One or more MovieIds are invalid.");

                foreach (var movie in movies)
                {
                    if (movie.NumberAvailable == 0)
                        return BadRequest($"{movie.Name } (${movie.ReleaseDate.Value.Year}) is not available.");
                    movie.NumberAvailable--;
                    Rental rental = new Rental()
                    {
                        Customer = customer,
                        Movie = movie,
                        DateRented = DateTime.Now,
                    };
                    _context.Rentals.Add(rental);
                }
                _context.SaveChanges();
                return Ok("Rentals successfully recorded!");
            }
            catch (Exception e)
            {
                return BadRequest("Fill all input fields appropriately.");
            }
            finally
            {
                _context.Dispose();
            }
        }
    }
}