namespace Pets.Data.Models.Cats
{
    using System.ComponentModel.DataAnnotations;
    using Pets.Data.Common.Models;
    using Pets.Core;
    using Pets.Core.Enums;

    public class Cat : BaseDeletableModel<string>
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