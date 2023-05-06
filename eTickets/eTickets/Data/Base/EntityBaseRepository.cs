using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.ID == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
        public async Task<T> GetByIDAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(n => n.ID == id);

        public async Task UpdateAsync(int id, T newEntity)
        {
            var existingEntity = await _context.Set<T>().FindAsync(id);
            if (existingEntity == null)
            {
                throw new ArgumentException("Entity with specified ID not found.", nameof(id));
            }

            // Update the entity properties
            _context.Entry(existingEntity).CurrentValues.SetValues(newEntity);

            try
            {
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency conflicts
                var entry = ex.Entries.Single();
                var databaseValues = entry.GetDatabaseValues();
                var clientValues = entry.CurrentValues.Clone();
                if (databaseValues == null)
                {
                    throw new ArgumentException("Entity has been deleted by another user.", nameof(id));
                }
                else
                {
                    // Update the entity with the database values and retry the operation
                    var databaseEntity = databaseValues.ToObject();
                    entry.CurrentValues.SetValues(databaseEntity);
                    await _context.SaveChangesAsync();
                }
            }
        }

    }
}