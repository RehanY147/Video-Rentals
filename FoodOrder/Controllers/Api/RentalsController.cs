using FoodOrder.Dtos;
using FoodOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace FoodOrder.Controllers.Api
{
    [Authorize]
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController() {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }

        public IHttpActionResult AddRental(RentalDto rentalDto) {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == rentalDto.CustomerId);

            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id));

            foreach(var movie in movies) {

                if(movie.NumberInStock<=0) {
                    return BadRequest("Movie '"+movie.Name+"' out of stock.");
                }
                movie.NumberInStock--;
                var rental = new Rental {
                    CustomerId = rentalDto.CustomerId,
                    MovieId = movie.Id,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);


            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
