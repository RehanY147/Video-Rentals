using FoodOrder.Models;
using FoodOrder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity.Validation;

namespace FoodOrder.Controllers {
    public class MoviesController : Controller {

        private ApplicationDbContext _context;
        public MoviesController() {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }
        // GET: Movies
        //public ActionResult Random() {
        //    var movie = new Movie() {
        //        Name = "Shrek!"
        //    };

        //    var customers = new List<Customer> {
        //        new Customer { Name="Customer 1" },
        //        new Customer { Name="Customer 2" }
        //    };

        //    var viewModel = new RandomMovieViewModel();
        //    viewModel.Movie = movie;
        //    viewModel.Customers = customers;


        //    return View(viewModel);
        //}

        public ViewResult Index() {
            
            if (User.IsInRole(RoleNames.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }


        public ActionResult Details(int id) {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movie);
        }

        [Authorize(Roles =RoleNames.CanManageMovies)]
        public ActionResult New() {

            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult Edit(int id) {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null) {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel(movie) {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.CanManageMovies)]
        public ActionResult Save(Movie movie) {
            if(!ModelState.IsValid) {
                var viewModel = new MovieFormViewModel(movie) {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0) {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            } else {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

    }

}