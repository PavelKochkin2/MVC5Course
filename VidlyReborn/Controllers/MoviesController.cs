using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VidlyReborn.Models;
using VidlyReborn.ViewModels;

namespace VidlyReborn.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Movies
        public ActionResult Random()
        {
            var customers = new List<Customer>
            {
                new Customer() {Name = "Customer 1"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Customers = customers,
                Movie = new Movie()
                {
                    Name = "Die hard"
                }
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            var vm = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList(),
                Movie = movie
            };

            return View("MovieForm" , vm);
        }

        public ActionResult Index()
        {
            if(User.IsInRole(RoleName.CanManageMovie))
                return View("List");
            return View("ReadOnlyList");
        }

        [Route("Movies/Released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content($"year: {year} , month: {month}");
        }

        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Include(m => m.Genre).Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult New()
        {
            var vm = new MovieFormViewModel()
            {
                Movie = new Movie(),
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm" , vm);
        }
    }
}