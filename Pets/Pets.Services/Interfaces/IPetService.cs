namespace Pets.Services.Interfaces
{
    using Data.Models;
    using Models;
    using System.Collections.Generic;

    public interface IPetService
    {
        IEnumerable<PetListingServiceModel> GetAll();
        PetServiceModel GetById(int id);
        PetServiceModel Create(Pet pet);
        PetServiceModel Edit(Pet dog);
        void DeleteById(int id);
    }
}