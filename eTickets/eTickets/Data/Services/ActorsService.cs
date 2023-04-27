using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;
        public ActorsService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(ActorModel actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ActorModel>> GetAll()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public ActorModel GetByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public ActorModel Update(int id, ActorModel newActor)
        {
            throw new System.NotImplementedException();
        }
    }
}
