using eTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<ActorModel>> GetAllAsync();
        Task<ActorModel> GetByIDAsync(int id);
        Task AddAsync(ActorModel actor);
        Task<ActorModel> UpdateAsync(int id, ActorModel newActor);
        Task DeleteAsync(int id);
    }
}
