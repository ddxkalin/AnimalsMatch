namespace Pets.Services.Implementations.Cats
{
    using Data;
    using Interfaces;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using Pets.Data.Common.Models;

    public class AdoptionDogService<T> : IAdoptionPetService<T>
        where T : BaseDeletableModel<string>
    {
        private readonly PetsDbContext db;

        public AdoptionDogService(PetsDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AdoptionPetListingServiceModel> Requested()
        {
            // TODO: AutoMapper

            var dogs = this.db.AdoptionDogs.Where(a => a.IsRequested);
            var result = new List<AdoptionPetListingServiceModel>();
            
            foreach (var dog in dogs)
            {
                var tempDog = new AdoptionPetListingServiceModel();
                // TODO: add properties 
                result.Add(tempDog);
            }
            return result;
        }

        public void Adopt(int id, string username)
        {
            var dog = this.db.AdoptionDogs.FirstOrDefault(c => c.Id == id);
            //var user = this.db.Users.FirstOrDefault(u => u.UserName == username); TODO: Fix this

            //if (dog == null || user == null || dog.OwnerId == user.Id)
            //{
            //    // TODO: Exception
            //}

            dog.IsRequested = true;
            // dog.RequestedOwnerId = user.Id;

            //this.db.SaveChanges();
        }

        public void Give(int id)
        {
            if (!this.db.AdoptionDogs.Any(c => c.Id == id))
            {
                // TODO: Exception
            }

            var dog = this.db.AdoptionDogs.FirstOrDefault(c => c.Id == id);
            // var owner = this.db.Users.FirstOrDefault(u => u.Id == dog.RequestedOwnerId);

            dog.IsRequested = false;
            dog.IsAdopted = true;
            //Todo: owner
            //dog.Owner = owner;

            //  this.db.SaveChanges();
        }
    }
}