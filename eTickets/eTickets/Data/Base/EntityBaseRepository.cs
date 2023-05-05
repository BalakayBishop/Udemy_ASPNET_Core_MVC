using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;
        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        // ----- Get All -----
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result;
        }

        // ----- Get One -----
        public async Task<T> GetByIDAsync(int id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(n => n.ID == id);
            return result;
        }

        // ----- Add New -----
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // ----- Update -----
        public async Task UpdateAsync(int id, T newEntity)
        {
            EntityEntry entry = _context.Entry<T>(newEntity);
            entry.State = EntityState.Modified;
        }

        // ----- Delete -----
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.ID == id);
            EntityEntry entry = _context.Entry<T>(entity);
            entry.State = EntityState.Deleted;
        }
    }
}
