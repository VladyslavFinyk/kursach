using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursach.Auth
{
    public class UserService
    {
        private ILogger<UserService> logger;
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private LinkGenerator linkGenerator;
        private IHttpContextAccessor httpContextAccessor;

        public UserService(
            ILogger<UserService> logger,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            LinkGenerator linkGenerator,
            IHttpContextAccessor httpContextAccessor)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.linkGenerator = linkGenerator;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> TryUserLoginAsync(string username, string password)
        {
            IdentityUser? user = await userManager.FindByNameAsync(username);

            if(user != null)
            {
                var signInResult = await signInManager.PasswordSignInAsync(user, password, false, false);

                if (signInResult.Succeeded)
                {
                    logger.LogInformation($"Succesfully signed in the user with username: {username}");
                    return true;
                }
                logger.LogError($"Unsuccesfull login for user with username: {username}");
            }
            else
            {
                logger.LogError($"Couldn't find user with username: {username}");
            }
            return false;
        }

        /*public async Task<IEnumerable<string>?> TrySignUpUserAsync(string username, string password, string email)
        {
            username = username.Trim();
        }*/
    }
}
