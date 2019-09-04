using System.Threading.Tasks;

namespace MoviesWebApp.Domain.Interfaces
{
    public interface IMovieService
    {
        Task<string> GetMovies(string baseURI, string apiKey, int page);
        Task<string> GetMovieDetail(string baseURI, string apiKey, int movieId);
        Task<string> SearchMovieByTitle(string baseURI, string apiKey, string title, int page);
    }
}
