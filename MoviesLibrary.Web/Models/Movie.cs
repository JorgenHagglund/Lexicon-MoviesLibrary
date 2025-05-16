using System.ComponentModel.DataAnnotations;

namespace MoviesLibrary.Web.Models;

public class Movie
{
    public int Id { get; set; }
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
}
