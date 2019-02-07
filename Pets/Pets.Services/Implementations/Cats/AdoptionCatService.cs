namespace Pets.Services.Implementations.Cats
{
    using Data;
    using Data.Models;
    using Interfaces;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class AdoptionCatService : IAdoptionPetService
    {
        private readonly PetsDbContext db;

        public AdoptionCatService(PetsDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<AdoptionPetListingServiceModel> Requested()
        {
            // TODO: AutoMapper
            var cats = this.db.AdoptionCats.Where(a => a.IsRequested);
            var result = new List<AdoptionPetListingServiceModel>();
            foreach (var cat in cats)
            {
                var tempCat = new AdoptionPetListingServiceModel();
                // TODO: add properties 
                result.Add(tempCat);
            }
            return result;
        }

        public void Adopt(int id, string username)
        {
            var cat = this.db.AdoptionCats.FirstOrDefault(c => c.Id == id);
            //var user = this.db.Users.FirstOrDefault(u => u.UserName == username); TODO: Fix this

            //if (cat == null || user == null || cat.OwnerId == user.Id)
            //{
            //    // TODO: Exception
            //}

            cat.IsRequested = true;
            // cat.RequestedOwnerId = user.Id;

            //this.db.SaveChanges();
        }

        public void Give(int id)
        {
            if (!this.db.AdoptionCats.Any(c => c.Id == id))
            {
                // TODO: Exception
            }

            var cat = this.db.AdoptionCats.FirstOrDefault(c => c.Id == id);
           // var owner = this.db.Users.FirstOrDefault(u => u.Id == cat.RequestedOwnerId);

            cat.IsRequested = false;
            cat.IsAdopted = true;
            cat.Owner = owner;

          //  this.db.SaveChanges();
        }
    }
}