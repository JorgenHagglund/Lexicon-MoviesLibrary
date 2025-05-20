using Microsoft.AspNetCore.Mvc;
using MoviesLibrary.Web.Models;
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
        View(new AddVM());

    [HttpPost("/add")]
    public IActionResult Add(AddVM viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        _movieService.AddMovie(new Movie
        {
            Title = viewModel.Title,
            OriginalTitle = viewModel.OriginalTitle,
            AlternateTitle = viewModel.AlternateTitle,
            Genres = viewModel.Genres,
            ReleaseDate = viewModel.ReleaseDate,
            Runtime = viewModel.Runtime,
            PosterUrl = viewModel.PosterUrl
        });
        return RedirectToAction("Index");
    }
}
