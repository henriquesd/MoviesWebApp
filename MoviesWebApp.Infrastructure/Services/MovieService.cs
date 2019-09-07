using MoviesWebApp.Domain.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoviesWebApp.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        public async Task<string> GetMovies(string baseURI, string apiKey, int page)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(baseURI + "api_key=" + apiKey + "&page=" + page.ToString());

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> GetMovieDetail(string baseURI, string apiKey, int movieId)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(baseURI + movieId.ToString() + "?api_key=" + apiKey);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> SearchMovieByTitle(string baseURI, string apiKey, string title, int page)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(baseURI + "api_key=" + apiKey + "&query=" + title + "&page=" + page.ToString() + "&primary_release_year=" + DateTime.Now.Year.ToString());

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
