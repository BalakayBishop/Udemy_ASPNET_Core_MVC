using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<MovieModel>, IMoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context) : base(context) { _context = context; }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new MovieModel()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                Cinema_ID = data.Cinema_ID,
                Start_Date = data.Start_Date,
                End_Date = data.End_Date,
                MovieCategory = data.MovieCategory,
                Producer_ID = data.Producer_ID
            };

            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            // Add Movie Actors
            foreach (var actorID in data.Actor_IDs)
            {
                var newActorMovie = new Actors_Movies()
                {
                    Movie_ID = newMovie.ID,
                    Actor_ID = actorID
                };

                await _context.Actors_Movies.AddAsync(newActorMovie);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<MovieModel> GetMovieIDAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.ID == id);

            return movieDetails;
        }

        public async Task<NewMovieDropDownVM> GetNewMovieDropDownsValues()
        {
            var response = new NewMovieDropDownVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }
}
}
