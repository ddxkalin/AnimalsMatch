namespace Pets.Data.Models.Dogs
{
    public class AdoptionDog : Dog
    {
        public bool IsAdopted { get; set; }

        public bool IsRequested { get; set; }

        public string RequestedOwnerId { get; set; }
    }
}