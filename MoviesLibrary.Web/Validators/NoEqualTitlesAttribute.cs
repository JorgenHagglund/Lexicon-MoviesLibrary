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
        if ((movie.Title == movie.OriginalTitle) || (movie.Title == movie.AlternateTitle) || (movie.OriginalTitle == movie.AlternateTitle))
            return new ValidationResult(ErrorMessage);
        return ValidationResult.Success;
    }
}
