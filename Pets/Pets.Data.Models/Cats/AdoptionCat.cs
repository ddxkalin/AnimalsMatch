﻿namespace Pets.Data.Models.Cats
{
    public class AdoptionCat : Cat
    {
        public bool IsAdopted { get; set; }

        public bool IsRequested { get; set; }

        public string RequestedOwnerId { get; set; }
    }
}