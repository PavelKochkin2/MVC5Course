using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using VidlyReborn.DTOs;
using VidlyReborn.Models;

namespace VidlyReborn.Controllers.Api
{
    public class RentMovieController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public RentMovieController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Rent(NewRentalDto request)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == request.CustomerId);

            var movies = _context.Movies.Where(m => request.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                movie.NumberAvailable--;
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            //temp
            return Ok(_context.Rentals);
        }
    }
}
