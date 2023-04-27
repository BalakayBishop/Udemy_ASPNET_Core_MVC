using eTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        // Get All
        Task<IEnumerable<ActorModel>> GetAllAsync();

        // Get One
        Task<ActorModel> GetByIDAsync(int id);

        // POST
        Task AddAsync(ActorModel actor);

        // PUT
        ActorModel Update(int id, ActorModel newActor);

        // DELETE
        void Delete(int id);
    }
}
