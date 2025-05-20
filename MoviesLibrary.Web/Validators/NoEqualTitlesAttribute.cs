using MoviesLibrary.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace MoviesLibrary.Web.Validators;

public class NoEqualTitlesAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
            return new ValidationResult(ErrorMessage);  

        var movie = (Movie)value;
        if (String.IsNullOrWhiteSpace(movie.OriginalTitle))
            return new ValidationResult(ErrorMessage);

        if ((!String.IsNullOrWhiteSpace(movie._title) && (movie._title == movie.OriginalTitle)) || 
            (!(String.IsNullOrWhiteSpace(movie._title) && String.IsNullOrWhiteSpace(movie.AlternateTitle)) && (movie._title == movie.AlternateTitle)) || 
            (!String.IsNullOrWhiteSpace(movie.AlternateTitle) && (movie.OriginalTitle == movie.AlternateTitle)))
            return new ValidationResult(ErrorMessage);
        return ValidationResult.Success;
    }
}
