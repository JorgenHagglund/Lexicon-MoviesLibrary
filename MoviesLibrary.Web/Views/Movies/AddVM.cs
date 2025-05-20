using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MoviesLibrary.Web.Validators;
using System.ComponentModel.DataAnnotations;

namespace MoviesLibrary.Web.Views.Movies;

[NoEqualTitles(ErrorMessage = "The titles must be different")]
public class AddVM
{
    [ValidateNever]
    [Display(Name = "Localized title", Description = "The title of the movie", Prompt = "Localized title")]
    public string Title { get; set; } = null!;
    [Required(ErrorMessage = "The movie needs a title")]
    [Display(Name = "Original title", Description = "The original title of the movie", Prompt = "Original title")]
    public string OriginalTitle { get; set; } = null!;
    [Display(Name = "Alternate title", Description = "An alternate title", Prompt = "Alternate title")]
    [ValidateNever]
    public string AlternateTitle { get; set; } = null!;
    [DataType(DataType.Duration)]
    public int Runtime { get; set; }
    [Display(Description = "The movie's genres", Prompt = "A comma-separated list of genres")]
    public string[] Genres { get; set; } = null!;
    public DateOnly ReleaseDate { get; set; }
    [Url(ErrorMessage = "Must be an URL")]
    [Display(Description = "The URL of the movie's poster", Prompt = "Poster URL")]
    public string PosterUrl { get; set; } = null!;
}
