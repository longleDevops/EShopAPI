using System;
using Microsoft.EntityFrameworkCore;
using OrderAPI.ApplicationCore.Contracts.Repositories;
using ProductAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repositories
{
	public class EfRepository<T>: IAsyncRepository<T> where T:class
    {
        protected readonly EShopDbContext _dbContext;

		public EfRepository(EShopDbContext dbContext)
		{
            _dbContext = dbContext;
		}

        public async Task<int> Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            // return the number of rows getting affected
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var item = await GetById(id);

            if (item != null)
            {
                _dbContext.Set<T>().Remove(item);
                return await _dbContext.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id) ;
        }

        public async Task<int> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }
    }

    
}

