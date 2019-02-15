namespace Pets.Data.Models.Dogs
{
    using System.ComponentModel.DataAnnotations;
    using Pets.Core;
    using Pets.Core.Enums;
    using Pets.Data.Common.Models;

    public class Dog : BaseDeletableModel<string>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(Constants.PetNameMinLength)]
        [MaxLength(Constants.PetNameMaxLength)]
        public string Name { get; set; }

        public int Age { get; set; }

        public byte[] Image { get; set; }

        [MinLength(Constants.PetDescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        public Gender Gender { get; set; }

        public string OwnerId { get; set; }

        public User Owner { get; set; }
    }
}