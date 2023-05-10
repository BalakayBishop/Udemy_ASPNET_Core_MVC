using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<MovieModel>
    {
        Task<MovieModel> GetMovieIDAsync(int id);

        Task<NewMovieDropDownVM> GetNewMovieDropDownsValues();

        Task AddNewMovieAsync(NewMovieVM data);
        
        Task UpdateMovieAsync(NewMovieVM data);
    }
}
