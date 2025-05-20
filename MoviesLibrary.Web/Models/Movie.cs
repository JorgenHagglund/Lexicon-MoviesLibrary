using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MoviesLibrary.Web.Validators;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace MoviesLibrary.Web.Models;

public class Movie
{
    public string _title = null!;
    public uint Id { get; set; }
    public string OriginalTitle { get; set; } = null!;
    public string Title
    {
        get => _title ?? OriginalTitle;
        set => _title = value;
    }
    public string AlternateTitle { get; set; } = null!;
    public int Runtime { get; set; }
    public string[] Genres { get; set; } = null!;
    public DateOnly ReleaseDate { get; set; }
    public string PosterUrl { get; set; } = null!;
}
