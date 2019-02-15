namespace Pets.Services.Implementations.Dogs
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Pets.Data.Common.Models;
    using Pets.Data.Common.Repositories;
    using Pets.Services.Interfaces;

    public class DogCrudService<T> : ICatCrudService<T>
        where T : BaseDeletableModel<string>
    {
        private IDeletableEntityRepository<T> data;

        public DogCrudService(IDeletableEntityRepository<T> data)
        {
            this.data = data;
        }

        public IQueryable<T> GetAll()
        {
            var result = this.data.All();

            return result;
        }

        public IQueryable<T> GetAllWithDeleted()
        {
            var result = this.data.AllWithDeleted();

            return result;
        }

        public async Task<T> Get(string id)
        {
            var entity = await this.data.GetByIdAsync(id);

            return entity;
        }

        public async Task<T> Create(T entity)
        {
            this.data.Add(entity);
            await this.data.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Update(T entity)
        {
            this.data.Update(entity);
            await this.data.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(string id)
        {
            var entity = await this.data.GetByIdAsync(id);

            if (entity != null)
            {
                this.data.Delete(entity);
                await this.data.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(IQueryable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.data.Delete(entity);
            }

            await this.data.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Restore(string id)
        {
            var entity = await this.data.GetByIdWithDeletedAsync(id);

            if (entity != null)
            {
                this.data.Undelete(entity);
                await this.data.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> Restore(IQueryable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.data.Undelete(entity);
            }

            await this.data.SaveChangesAsync();
            return true;
        }

        public Task<bool> Exists(string name)
        {
            var exists = this.data.All().AnyAsync(x => x.Name == name);

            return exists;
        }
    }
}