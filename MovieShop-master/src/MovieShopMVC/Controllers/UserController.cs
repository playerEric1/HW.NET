using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;

        public UserController(IUserService userService, IMovieService movieService,
            ICurrentUserService currentUserService)
        {
            _userService = userService;
            _movieService = movieService;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> BuyMovie(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> BuyMovie(PurchaseRequestModel purchase)
        {
            // await _userService(purchase, _currentUserService.UserId);
            return Ok();
        }

        public async Task<IActionResult> Purchases(int id)
        {
            var movies = await _userService.GetAllPurchasesForUser(id);
            return View();
        }
    }
}