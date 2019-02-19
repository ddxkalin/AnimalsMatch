namespace Pets.Services.Identity
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Pets.Data.Models;

    public class ApplicationUserManager<TUser> : UserManager<ApplicationUser>
        where TUser : ApplicationUser
    {
        public ApplicationUserManager(
            IUserStore<ApplicationUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<ApplicationUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors,
                services, logger)
        {
        }

        //public object GetUserId(ClaimsPrincipal user)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<IdentityResult> ActivateUserAsync(string userId)
        {
            if (userId == null)
            {
                throw new InvalidOperationException("userId");
            }

            ApplicationUser user = await this.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("user");
            }

            user.IsActive = true;

            return await this.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeactivateUserAsync(string userId)
        {
            if (userId == null)
            {
                throw new InvalidOperationException("userId");
            }

            ApplicationUser user = await this.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("user");
            }

            user.IsActive = false;

            return await this.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteUserAsync(string userId)
        {
            if (userId == null)
            {
                throw new InvalidOperationException("userId");
            }

            ApplicationUser user = await this.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("user");
            }

            user.IsDeleted = true;

            return await this.UpdateAsync(user);
        }

        public async Task<IdentityResult> RestoreUserAsync(string userId)
        {
            if (userId == null)
            {
                throw new InvalidOperationException("userId");
            }

            ApplicationUser user = await this.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("user");
            }

            user.IsDeleted = false;

            return await this.UpdateAsync(user);
        }

        public async Task<IdentityResult> UnlockUserAsync(string userId)
        {
            if (userId == null)
            {
                throw new InvalidOperationException("userId");
            }

            ApplicationUser user = await this.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("user");
            }

            user.LockoutEnd = DateTime.UtcNow;

            return await this.UpdateAsync(user);
        }

        public async Task<IdentityResult> SetEmailConfirmationTokenResentOnAsync(string userId)
        {
            if (userId == null)
            {
                throw new InvalidOperationException("userId");
            }

            ApplicationUser user = await this.FindByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException("user");
            }

            user.EmailConfirmationTokenResentOn = DateTime.UtcNow;

            return await this.UpdateAsync(user);
        }
    }
}
