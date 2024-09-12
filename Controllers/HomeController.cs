using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mo240912.Models;
using System.Diagnostics;

namespace Mo240912.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly movieContext _movieContext;

        public HomeController(ILogger<HomeController> logger, movieContext movieContext)
        {
            _logger = logger;
            _movieContext = movieContext;
        }

        public IActionResult Index()
        {
            var model = _movieContext.Movies.ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Order()
        {
            var model = _movieContext.Seats.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateAvailability([FromBody] SeatUpdateModel model)
        {
            if (model?.Seats == null || !model.Seats.Any())
            {
                return BadRequest("No seats provided.");
            }

            var seatsToUpdate = _movieContext.Seats
                .Where(s => model.Seats.Contains(s.SeatNumber))
                .ToList();

            if (seatsToUpdate.Any())
            {
                foreach (var seat in seatsToUpdate)
                {
                    seat.IsAvailable = "N";  // 假設座位訂購後不可再用
                }
                _movieContext.SaveChanges();
                return Ok("Seats updated successfully.");
            }
            return NotFound("No matching seats found.");
        }

        public class SeatUpdateModel
        {
            public List<string> Seats { get; set; } = new List<string>();
        }

        public IActionResult Programs()
        {
            var movies = _movieContext.Movies.ToList();
            var showtimes = _movieContext.Showtimes.ToList();

            var viewModel = new MovieSeat
            {
                Movies = movies,
                Showtimes = showtimes
            };

            return View(viewModel);

            
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
