namespace Pets.Data.Models
{
    using Core;
    using Core.Enums;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.ComponentModel.DataAnnotations;
    using Validation;

    public class User : IdentityUser
    {
        [Required]
        [MinLength(Constants.UserNameMinLength)]
        [MaxLength(Constants.UserNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Location]
        public string Location { get; set; }

        [Birthday]
        public DateTime Birthdate { get; set; }

        [Required]
        public byte[] ProfilePhoto { get; set; }

        public Gender Gender { get; set; }

        public bool IsAdmin { get; set; }
    }
}