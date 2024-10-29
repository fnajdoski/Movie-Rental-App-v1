using Microsoft.EntityFrameworkCore;
using MovieRentalApp.Models;

namespace MovieRentalApp.Data
{
    public class MovieRentalContext : DbContext
    {
        public MovieRentalContext(DbContextOptions<MovieRentalContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
