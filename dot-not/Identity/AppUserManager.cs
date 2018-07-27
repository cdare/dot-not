using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dot_not.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace dot_not.Identity
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        {
        }

        // this method is called by Owin therefore best place to configure your User Manager
        public static AppUserManager Create(
            IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var manager = new AppUserManager(
                new UserStore<AppUser>(context.Get<DotNotDBContext>()));
            manager.UserValidator = new UserValidator<AppUser>(manager)
            {
                // This disables the validation check on email addresses
                RequireUniqueEmail = false
            };

            return manager;
        }
    }
}