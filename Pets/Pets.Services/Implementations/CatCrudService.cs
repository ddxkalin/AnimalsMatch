namespace Pets.Services.Implementations
{
    using System.Linq;
    using Pets.Data.Common.Models;
    using Pets.Data.Common.Repositories;
    using Pets.Services.Interfaces;

    public class CatCrudService<T> : ICatCrudService<T>
        where T : BaseDeletableModel<string>
    {
        private IDeletableEntityRepository<T> data;

        public CatCrudService(IDeletableEntityRepository<T> data)
        {
            this.data = data;
        }

        //private readonly IPetsDbContext context;

        //public CatCrudService(IPetsDbContext db)
        //{
        //    this.context = db;
        //}

        public IQueryable<T> GetAll()
        {
            var result = this.data.All();

            return result;

        }

        //public Cat Create(Cat cat)
        //{
        //    Cat result = this.context.Pets.Add(cat);
        //    this.context.SaveChanges();

        //    return result;
        //}

        //public Cat GetById(int id)
        //{
        //    return this.context.Cats.FirstOrDefault(u => u.ID == id);
        //}

        //public void DeleteById(int id)
        //{
        //    Cat entity = this.GetById(id);

        //    this.context.Cats.Remove(entity);
        //    this.context.SaveChanges();
        //}

        //public Cat Update(Cat cat)
        //{
        //    Cat result = this.context.Cats.Attach(cat);
        //    this.context.SaveChanges();

        //    return result;
        //}
    }
}
