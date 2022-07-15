using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketShop.Data;

namespace TicketShop.Models.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly TicketShopDbContext _Context;

        public MovieRepository(TicketShopDbContext context)
        {
            _Context = context;
        }

        public MovieModel AddMovie(MovieModel movieToAdd)
        {
            _Context.Movies.Add(movieToAdd);
            _Context.SaveChanges();
            return movieToAdd;
        }

        public IEnumerable<MovieModel> GetAllMovies()
        {
            var movies = _Context.Movies;
            return movies;
        }

        public MovieModel GetMovie(int movieId)
        {
            var movie = _Context.Movies.Find(movieId);
            return movie;
        }

        public MovieModel RemoveMovie(int movieId)
        {
            var movie = _Context.Movies.Find(movieId);
            if (movie != null)
            {
                _Context.Movies.Remove(movie);
                _Context.SaveChanges();
            }
            return movie;
        }

        public MovieModel UpdateMovie(MovieModel movieChanges)
        {
            var movie = _Context.Movies.Attach(movieChanges);
            movie.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _Context.SaveChanges();
            return movieChanges;
        }
    }
}
