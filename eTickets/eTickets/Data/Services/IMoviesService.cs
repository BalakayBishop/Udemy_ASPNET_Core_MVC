using eTickets.Data.Base;
using eTickets.Models;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<MovieModel>
    {
        Task<MovieModel> GetMovieIDAsync(int id);
    }
}
