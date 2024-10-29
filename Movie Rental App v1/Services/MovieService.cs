using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRentalApp.DTOs;
using MovieRentalApp.Models;
using MovieRentalApp.Repositories;

namespace MovieRentalApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDTO>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MovieDTO>>(movies);
        }

        public async Task<MovieDTO> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return _mapper.Map<MovieDTO>(movie);
        }

        public async Task AddMovieAsync(MovieDTO movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            await _movieRepository.AddAsync(movie);
        }

        public async Task UpdateMovieAsync(MovieDTO movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            await _movieRepository.UpdateAsync(movie);
        }

        public async Task DeleteMovieAsync(int id)
        {
            await _movieRepository.DeleteAsync(id);
        }
    }
}
