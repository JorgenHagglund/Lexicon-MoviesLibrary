using Microsoft.Extensions.Logging;
using MoviesLibrary.Web.Models;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MoviesLibrary.Web.Services;

public class MovieService(ILogger<MovieService> logger)
{
    static List<Movie> movies = [];
    static uint mextId;
    readonly string path = Path.Combine(AppContext.BaseDirectory, "Movies.json");
    //readonly ILogger<MovieService> logger;

    //public MovieService()
    //{
    //    // Load the movies from the file
    //    // Can't do this here... Do it from the controller
    //    //await Load();

    //    /*        movies = JsonSerializer.Deserialize<List<Movie>>(File.ReadAllText(path)) ?? [];
    //            mextId = movies.Count == 0 ? 1 : movies.Max(m => m.Id) + 1; */
    //}

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

        // Also moved to controller, to avoid async void
        //await Save();
        // Save to file
        File.WriteAllText(path, JsonSerializer.Serialize(movies));
    }

    public async Task LoadAsync()
    {
        try
        {
            await using FileStream openStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.None);
            movies = await JsonSerializer.DeserializeAsync<List<Movie>>(openStream) ?? [];
        }
        // Accept all errors, just log and keep movies empty
        catch (FileNotFoundException) { }
        catch (JsonException ex)
        {
            logger.LogError($"An error occurred while reading the file {path}: {ex.Message}", ex);
        }
        catch (UnauthorizedAccessException)
        {
            logger.LogWarning($"Access to the file {path} is denied.");
        }
        catch (IOException ex) {
            logger.LogCritical($"IO Failure: {ex.Message}");
        }
    }
    public async Task SaveAsync()
    {
        using FileStream openStream = File.Open(path, FileMode.Create, FileAccess.Write, FileShare.None);
        await JsonSerializer.SerializeAsync(openStream, movies);
    }
}
