using MoviesLibrary.Web.Models;
using System.Text.Json;

namespace MoviesLibrary.Web.Services;

public class MovieService
{
    static List<Movie> movies = [];
    static uint mextId;
    readonly string path = Path.Combine(AppContext.BaseDirectory, "Movies.json");

    public MovieService()
    {
        movies = JsonSerializer.Deserialize<List<Movie>>(File.ReadAllText(path)) ?? [];
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

        // Save to file
        File.WriteAllText(path, JsonSerializer.Serialize(movies));
    }
}
