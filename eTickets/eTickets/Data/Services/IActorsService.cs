using eTickets.Models;
using System.Collections.Generic;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        IEnumerable<ActorModel> GetAll();

        ActorModel GetByID(int id);

        void Add(ActorModel actor);

        ActorModel Update(int id, ActorModel newActor);

        void Delete(int id);
    }
}
