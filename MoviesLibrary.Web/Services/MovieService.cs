using MoviesLibrary.Web.Models;
using System.Text.Json;

namespace MoviesLibrary.Web.Services;

public class MovieService
{
    static List<Movie> movies = new();
    static uint mextId;

    public MovieService()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Movies.json");
        movies = JsonSerializer.Deserialize<List<Movie>>(File.ReadAllText(path)) ?? new List<Movie>();
        mextId = movies.Count == 0 ? 1 : movies.Max(m => m.Id) + 1;   
    }

    public Movie[] GetAllMovies() => 
        movies
            .OrderBy(m => m.Title)
            .ThenBy(m => m.OriginalTitle)
            .ThenBy(m => m.AlternateTitle)
            .ToArray();

    public Movie? GetMovie(int id) =>
        movies.SingleOrDefault(m => m.Id == id);

    public void AddMovie(Movie movie)
    {
        if (movie.Id == 0)
            movie.Id = mextId++;
        movies.Add(movie);
    }
}
