using MoviesLibrary.Web.Validators;
using System.ComponentModel.DataAnnotations;

namespace MoviesLibrary.Web.Models;

[NoEqualTitles(ErrorMessage = "The titles must be different")]
public class Movie
{
    public uint Id { get; set; }
    [Required(ErrorMessage = "The movie needs a title")]
    [Display(Description = "The title of the movie", Prompt = "Localized title")]
    public string Title { get; set; }

    [Display(Description = "The original title of the movie", Prompt = "Original title")]
    public string OriginalTitle { get; set; }

    [Display(Description = "An alternate title", Prompt = "Alternate title")]
    // TODO: Custom validation
    public string AlternateTitle { get; set; }

    [DataType(DataType.Duration)]
    public int Runtime { get; set; }

    public string[] Genres { get; set; }

    public DateOnly ReleaseDate { get; set; }

    public string PosterUrl { get; set; }
}
