using eTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        // Get All
        Task<IEnumerable<ActorModel>> GetAll();

        // Get One
        ActorModel GetByID(int id);

        // POST
        void Add(ActorModel actor);

        // PUT
        ActorModel Update(int id, ActorModel newActor);

        // DELETE
        void Delete(int id);
    }
}
