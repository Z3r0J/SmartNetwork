using Microsoft.EntityFrameworkCore;
using SmartNetwork.Core.Application.Interfaces.Repository;
using SmartNetwork.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartNetwork.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly ApplicationContext _applicationContext;
        public GenericRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public virtual async Task<Entity> AddAsync(Entity entity) {

            await _applicationContext.AddAsync(entity);
            await _applicationContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<List<Entity>> GetAllAsync() {

            return await _applicationContext.Set<Entity>().ToListAsync();
        
        }

        public virtual async Task<Entity> GetByIdAsync(int id) {

            return await _applicationContext.Set<Entity>().FindAsync(id);

        }

        public virtual async Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties) {

            var query = _applicationContext.Set<Entity>().AsQueryable();

            foreach (var prop in properties)
            {
                query = query.Include(prop);
            }

            return await query.ToListAsync();
        }

        public async Task UpdateAsync(Entity entity,int id) {

            var entry = await _applicationContext.Set<Entity>().FindAsync(id);
            _applicationContext.Entry(entry).CurrentValues.SetValues(entity);

            await _applicationContext.SaveChangesAsync();
        
        }

        public virtual async Task DeleteAsync(Entity entity) {

            _applicationContext.Set<Entity>().Remove(entity);
            await _applicationContext.SaveChangesAsync();

        }
    }
}
