using Demጽ.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demጽ.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly AppDbContext _appDbContext;
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

                
        }

        public async Task<T> Add(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
            
        }

        public async Task<T> Delete(string id)
        {
            var entity = await _appDbContext.Set<T>().FindAsync(id);
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));

            }
             _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
                    }

        public async Task<T> Get(string id)
        {
            var entity = await _appDbContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));

            }
            return entity;

        }

        public async Task<List<T>> GetAll()
        {
            var entities = await _appDbContext.Set<T>()
                .ToListAsync();
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));

            }
            return entities;
        }
        public async Task<List<T>> GetFirst(int count)
        {
            var entities = await _appDbContext.Set<T>().Take(count)
                .ToListAsync();

            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));

            }
            return entities;
        }
        public async Task<List<T>> GetLast(int count)
        {
            var entities = await _appDbContext.Set<T>()
                .ToListAsync();
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));

            }
            return entities;
        }

        public async Task<T> Update(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
