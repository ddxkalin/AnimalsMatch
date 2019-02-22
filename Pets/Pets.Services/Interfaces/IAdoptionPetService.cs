namespace Pets.Services.Interfaces
{
    using Models;
    using System.Collections.Generic;
    using Pets.Data.Common.Models;

    public interface IAdoptionPetService<T> where T : BaseDeletableModel<string>
    {
        IEnumerable<AdoptionPetListingServiceModel> Requested();
        void Adopt(int id, string username);
        void Give(int id);
    }
}