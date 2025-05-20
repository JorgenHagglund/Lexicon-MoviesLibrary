namespace MoviesLibrary.Web.Views.Movies;

public class DetailsVM
{
    public required string Title { get; set; } = null!;
    public required string OriginalTitle { get; set; } = null!;
    public required string AlternateTitle { get; set; } = null!;
    public required int Runtime { get; set; }
    public required string[] Genres { get; set; } = null!;
    public required DateOnly ReleaseDate { get; set; }
    public required string PosterUrl { get; set; } = null!;
}
