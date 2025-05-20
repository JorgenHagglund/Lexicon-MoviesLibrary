using Microsoft.AspNetCore.Mvc;
using MoviesLibrary.Web.Services;
using MoviesLibrary.Web.Views.Movies;

namespace MoviesLibrary.Web.Controllers;

public class MoviesController : Controller
{
    static readonly MovieService _movieService = new();

    [HttpGet("/")]
    public IActionResult Index() =>
        View(new IndexVM
        {
            Movies =
                _movieService.GetAllMovies()
                    .Select(m => new IndexVM.MovieVM
                    {
                        Id = m.Id,
                        Title = m.Title,
                        Genres = m.Genres,
                        ReleaseDate = m.ReleaseDate,
                        Runtime = m.Runtime
                    })
                    .ToArray(),
        });


    [HttpGet("/details")]
    public IActionResult Details(int id)
    {
        var movie = _movieService.GetMovie(id);
        if (movie == null)
            return NotFound();

        return View(new DetailsVM
        {
            AlternateTitle = movie.AlternateTitle,
            Genres = movie.Genres,
            OriginalTitle = movie.OriginalTitle,
            PosterUrl = movie.PosterUrl,
            ReleaseDate = movie.ReleaseDate,
            Runtime = movie.Runtime,
            Title = movie.Title
        });
    }

    [HttpGet("/add")]
    public IActionResult Add() =>
        View(new Models.Movie());

    [HttpPost("/add")]
    public IActionResult Add(Models.Movie movie)
    {
        if (ModelState.IsValid)
        {
            _movieService.AddMovie(movie);
            return RedirectToAction("Index");
        }
        return View(movie);
    }
}
