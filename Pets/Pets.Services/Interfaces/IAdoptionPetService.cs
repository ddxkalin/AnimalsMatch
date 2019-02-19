﻿namespace Pets.Services.Interfaces
{
    using Models;
    using System.Collections.Generic;

    public interface IAdoptionPetService<T>
    {
        IEnumerable<AdoptionPetListingServiceModel> Requested();
        void Adopt(int id, string username);
        void Give(int id);
    }
}