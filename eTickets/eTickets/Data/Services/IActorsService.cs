using eTickets.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<ActorModel>> GetAll();

        ActorModel GetByID(int id);

        void Add(ActorModel actor);

        ActorModel Update(int id, ActorModel newActor);

        void Delete(int id);
    }
}
