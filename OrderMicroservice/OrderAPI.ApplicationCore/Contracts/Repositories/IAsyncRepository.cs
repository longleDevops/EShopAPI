using System;
using OrderAPI.ApplicationCore.Entities;

namespace OrderAPI.ApplicationCore.Contracts.Repositories
{
	public interface IAsyncRepository<T> where T:class
	{
        Task<ICollection<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Create(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
    }
}

