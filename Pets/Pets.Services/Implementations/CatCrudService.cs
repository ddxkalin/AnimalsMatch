using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pets.Data;
using Pets.Data.Models.Cats;
using Pets.Services.Interfaces;

namespace Pets.Services.Implementations
{
    public class CatCrudService : ICatCrudService
    {
        private readonly IPetsDbContext context;

        public CatCrudService(IPetsDbContext db)
        {
            this.context = db;
        }

        public IQueryable<Cat> GetAll()
        {
            return this.context.Cats.AsQueryable();
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
