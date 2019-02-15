namespace Pets.Data.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Pets.Data.Common.Models;
    using Pets.Data.Models.Cats;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset EmailConfirmationTokenResentOn { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; } =
            new HashSet<IdentityUserRole<string>>();

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; } =
            new HashSet<IdentityUserClaim<string>>();

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; } =
            new List<IdentityUserLogin<string>>();

        public virtual ICollection<Cat> Cats { get; set; } = new HashSet<Cat>();
    }
}

