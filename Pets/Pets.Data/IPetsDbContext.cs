using Microsoft.EntityFrameworkCore;
using Pets.Data.Models;
using Pets.Data.Models.Cats;
using Pets.Data.Models.Dogs;

namespace Pets.Data
{
    public interface IPetsDbContext
    {
        DbSet<User> Users { get; set; }

        DbSet<Dog> Dogs { get; set; }

        DbSet<Pet> Pets { get; set; }

        DbSet<AdoptionDog> AdoptionDogs { get; set; }

        DbSet<Cat> Cats { get; set; }

        DbSet<AdoptionCat> AdoptionCats { get; set; }

        int SaveChanges();
    }
}
