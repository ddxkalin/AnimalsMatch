namespace Pets.Services.Implementations
{
    using Data;
    using Data.Models;
    using Interfaces;
    using Models;
    using System.Collections.Generic;

    public class PetService : IPetService
    {
        private readonly PetsDbContext db;

        public PetService(PetsDbContext db)
        {
            this.db = db;
        }

        public PetServiceModel Create(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public PetServiceModel Edit(Pet dog)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PetListingServiceModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public PetServiceModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}