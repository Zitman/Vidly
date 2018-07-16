using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //Optimistic approach
        //POST /api/rentals
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalsDto newRental)
        {
            var customer = _context.Customers.Single
                (c => c.Id == newRental.CustomerId);

            var movies = _context.Movies.Where(
                m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

    }
}

/*

    In CreateNewRentals if you need to check the customer is valid then:
var customer = _context.Customers.SingleOrDefault
(c => c.Id == newRental.CustomerId);

if (customer -- null)
    return BadRequest("Invalid customer id.")
*/


/*Defensive approach
//POST /api/rentals
[HttpPost]
public IHttpActionResult CreateNewRentals(NewRentalsDto newRental)
{
    if (newRental.MovieIds.Count == 0)
        return BadRequest("No movies selected.");

    var customer = _context.Customers.SingleOrDefault(
        c => c.Id == newRental.CustomerId);

    if (customer == null)
        return BadRequest("Invalid customer");

    var movies = _context.Movies.Where(
        m => newRental.MovieIds.Contains(m.Id)).ToList();

    if (movies.Count != newRental.MovieIds.Count)
        return BadRequest("One or more movies is invalid.");

    foreach (var movie in movies)
    {
        movie.NumberAvailable--;
        if (movie.NumberAvailable == 0)
            return BadRequest("Movie is not available.");

        var rental = new Rental
        {
            Customer = customer,
            Movie = movie,
            DateRented = DateTime.Now
        };
        _context.Rentals.Add(rental);
    }

    _context.SaveChanges();

    return Ok();
}
*/
