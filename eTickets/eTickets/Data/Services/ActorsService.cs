using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task AddAsync(ActorModel actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<ActorModel>> GetAllAsync()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public async Task<ActorModel> GetByIDAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Actor_ID == id);
            return result;
        }

        public ActorModel Update(int id, ActorModel newActor)
        {
            throw new System.NotImplementedException();
        }
    }
}
