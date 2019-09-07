using MoviesWebApp.API.Dtos;
using System;

namespace MoviesWebApp.API.Extensions
{
    public static class DtoHelper
    {
        public static void FormatImagePath(this UpcomingMoviesDto moviesDto, string imageUri)
        {
            foreach (var item in moviesDto.Results)
            {
                item.PosterPath = !String.IsNullOrEmpty(item.PosterPath) ? imageUri + item.PosterPath : null;
            }
        }
    }
}
