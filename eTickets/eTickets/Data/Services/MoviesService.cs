using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class MoviesService : EntityBaseRepository<MovieModel>, IMoviesService
    {
        public MoviesService(AppDbContext _context) : base(_context) { }
    }
}
