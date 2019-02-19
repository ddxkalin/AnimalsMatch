namespace Pets.Services.Identity
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Pets.Data.Models; 

    public class ApplicationSignInManager<TUser> : SignInManager<ApplicationUser>
        where TUser : ApplicationUser
    {
        public ApplicationSignInManager(
            ApplicationUserManager<ApplicationUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<ApplicationUser>> logger,
            IAuthenticationSchemeProvider schemeProvider)

        //TODO: Can't take 6 arguments dafuq?!

        : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemeProvider)
        {
        }

        public override async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool rememberMe, bool lockoutOnFailure)
        {
            var user = await this.UserManager.FindByEmailAsync(userName);

            if (user == null || !user.IsActive || user.IsDeleted)
            {
                return SignInResult.NotAllowed;
            }

            return await this.PasswordSignInAsync(user, password, rememberMe, lockoutOnFailure: lockoutOnFailure);
        }
    }
}
