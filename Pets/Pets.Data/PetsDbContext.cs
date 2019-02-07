namespace Pets.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models.Cats;
    using Models.Dogs;

    public class PetsDbContext : IdentityDbContext
    {
        public PetsDbContext(DbContextOptions<PetsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dog> Dogs { get; set; }

        public DbSet<AdoptionDog> AdoptionDogs { get; set; }

        public DbSet<Cat> Cats { get; set; }

        public DbSet<AdoptionCat> AdoptionCats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}