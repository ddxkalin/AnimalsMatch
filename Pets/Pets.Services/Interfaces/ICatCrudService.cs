﻿namespace Pets.Services.Interfaces
{
    using System.Threading.Tasks;
    using System.Linq;
    using Pets.Data.Common.Models;

    public interface ICatCrudService<T> where T : BaseDeletableModel<string>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAllWithDeleted();
        Task<T> Get(string id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(string id);
        Task<bool> Delete(IQueryable<T> entities);
        Task<bool> Restore(string id);
        Task<bool> Restore(IQueryable<T> entities);
        Task<bool> Exists(string name);
    }
}
