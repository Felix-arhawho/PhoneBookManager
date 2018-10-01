using Microsoft.AspNet.Identity.EntityFramework;
using PhonebookManager.DataAccess.Context;
using PhonebookManager.DataAccess.Identity;
using PhonebookManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookManager.DataAccess.Migrations.DataHelpers
{
    public class UserDataHelper
    {
        public static async Task<string> CreateAdminUser(PhonebookManagerContext context)
        {
            const string emailAddress = "admin@phonebookmanager.com";
            const string password = "micr0s0ft_";

            var phonebookUserManager = new PhonebookUserManager(new UserStore<User>(context));

            var user = await phonebookUserManager.FindByEmailAsync(emailAddress);

            if(user == null)
            {
                user = new User
                {
                    Email = emailAddress,
                    UserName = emailAddress,
                };
                await phonebookUserManager.CreateAsync(user, password);
            }
            return string.Empty;
        }
    }
}
