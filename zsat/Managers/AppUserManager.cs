using Microsoft.AspNetCore.Identity;
using zsat.Interfaces;
using zsat.Models;

namespace zsat.Managers
{
    public class AppUserManager : IAppUser
    {
        private readonly ZsatDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public AppUserManager(ZsatDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public AppUser SignUp(string name, string email, string password)
        {
            AppUser user = new() { Name = name, Email = email, UserName = email};
            IdentityResult result = _userManager.CreateAsync(user, password).Result;
            return user;
        }
    }
}
