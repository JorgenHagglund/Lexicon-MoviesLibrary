namespace MoviesLibrary.Web.Views.Movies;

public class IndexVM
{
    public required MovieVM[] Movies { get; set; }

    public class MovieVM
    {
        public required uint Id { get; set; }
        public required string Title { get; set; }
        public required string[] Genres { get; set; }
        public required DateOnly ReleaseDate { get; set; }
        public required int Runtime { get; set; }
    }
}
