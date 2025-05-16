using Microsoft.AspNetCore.Mvc;
using MoviesLibrary.Web.Services;

namespace MoviesLibrary.Web.Controllers;

public class MoviesController : Controller
{
    readonly MovieService _movieService = new();

    [HttpGet("/")]
    public IActionResult Index() =>
        View(_movieService.GetAllMovies());
}
