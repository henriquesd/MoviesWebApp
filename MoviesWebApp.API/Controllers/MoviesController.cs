using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MoviesWebApp.API.Dtos;
using MoviesWebApp.API.Extensions;
using MoviesWebApp.Domain.Interfaces;
using Newtonsoft.Json;

namespace MoviesWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApiSettings _apiSettings;

        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService,
                                IOptions<ApiSettings> apiSettings)
        {
            _movieService = movieService;
            _apiSettings = apiSettings.Value;
        }

        [HttpGet]
        public async Task<IActionResult> GetUpcomingMovies([FromQuery] int page = 1)
        {
            try
            {
                var movies = await _movieService.GetMovies(_apiSettings.UpcomingMoviesUri, _apiSettings.ApiKey, page);

                var moviesDto = JsonConvert.DeserializeObject<UpcomingMoviesDto>(movies);
                moviesDto.FormatImagePath(_apiSettings.ImageUri);

                return Ok(moviesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [Route("details/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetMovieDetail(int id)
        {
            try
            {
                var movies = await _movieService.GetMovieDetail(_apiSettings.MovieDetailUri, _apiSettings.ApiKey, id);

                var moviesDto = JsonConvert.DeserializeObject<MovieDetailDto>(movies);

                moviesDto.PosterPath = !String.IsNullOrEmpty(moviesDto.PosterPath) ? _apiSettings.ImageUri + moviesDto.PosterPath : null;
                
                return Ok(moviesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [Route("search/{title}")]
        [HttpGet]
        public async Task<IActionResult> SearchMovieByTitle(string title, int page = 1)
        {
            try
            {
                var movies = await _movieService.SearchMovieByTitle(_apiSettings.SearchMovieUri, _apiSettings.ApiKey, title, page);

                var moviesDto = JsonConvert.DeserializeObject<UpcomingMoviesDto>(movies);
                DtoHelper.FormatImagePath(moviesDto, _apiSettings.ImageUri);

                return Ok(moviesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}