using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRentalApp.DTOs;

namespace MovieRentalApp.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDTO>> GetAllMoviesAsync();
        Task<MovieDTO> GetMovieByIdAsync(int id);
        Task AddMovieAsync(MovieDTO movieDto);
        Task UpdateMovieAsync(MovieDTO movieDto);
        Task DeleteMovieAsync(int id);
    }
}
