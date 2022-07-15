using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketShop.Models.Repository
{
    public interface IMovieRepository
    {
        MovieModel GetMovie(int movieId);
        IEnumerable<MovieModel> GetAllMovies();
        MovieModel AddMovie(MovieModel movieToAdd);
        MovieModel UpdateMovie(MovieModel movieChanges);
        MovieModel RemoveMovie(int movieId);
    }
}
