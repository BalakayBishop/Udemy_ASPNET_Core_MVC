using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        // ----- GET ALL USERS -----
        public async Task<IEnumerable<ActorModel>> GetAllAsync()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        // ----- GET SINGLE USER -----
        public async Task<ActorModel> GetByIDAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.ID == id);
            return result;
        }

        // ----- ADD NEW USER -----
        public async Task AddAsync(ActorModel actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        // ----- UPDATE USER -----
        public async Task<ActorModel> UpdateAsync(int id, ActorModel updateActor)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(a => a.ID == id);

            if (actor != null)
            {
                actor.FullName = updateActor.FullName;
                actor.ProfilePicURL = updateActor.ProfilePicURL;
                actor.Biography = updateActor.Biography;

                await _context.SaveChangesAsync();
            }

            return actor;
        }

        // ----- DELETE USER -----
        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(a => a.ID == id);
            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
        }

    }
}