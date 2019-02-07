namespace Pets.Services.Implementations
{
    using Data;
    using Data.Models;
    using Interfaces;
    using Models;
    using System.Collections.Generic;

    public class AdoptionPetService : IPetService, IAdoptionPetService
    {
        private readonly PetsDbContext db;

        public AdoptionPetService(PetsDbContext db)
        {
            this.db = db;
        }

        public void Adopt(int id, string username)
        {
            throw new System.NotImplementedException();
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

        public void Give(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AdoptionPetListingServiceModel> Requested()
        {
            throw new System.NotImplementedException();
        }
    }
}