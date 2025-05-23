using MoviesLibrary.Web.Services;

namespace MoviesLibrary.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Logging
            .ClearProviders()
            .AddConsole()
            .AddDebug();
        builder.Services.AddSingleton<MovieService>();
        builder.Services.AddControllersWithViews();

        var app = builder.Build();
        app.MapControllers();
        app.UseStaticFiles();
        app.Run();
    }
}
