using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PropertyManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PropertyManager.Core.Infrastructure
{
    public class AuthRepository : IDisposable
    {
        private PropertyManagerDbContext _ctx;

        private UserManager<IdentityUser> _userManager;


        public AuthRepository()
        {
            _ctx = new PropertyManagerDbContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;

        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }


        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}
