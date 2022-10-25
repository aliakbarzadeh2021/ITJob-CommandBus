using System;
using System.Linq;
using ITJob.SecurityService.Repository.DbContexts;
using ITJob.SecurityService.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ITJob.SecurityService.Repository.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Repository\Migrations";
        }

        protected override void Seed(AuthContext context)
        {
            const string nationalCode = "0070238146";
            const string userName = "0070238146";
            const string password = "0070238146";
            const string roleName = "Admin";

            var appUserStore = new UserStore<ApplicationUser>(context);
            var appUserManager = new UserManager<ApplicationUser>(appUserStore);
            var appRoleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(context));

            try
            {
                var user = context.Users.SingleOrDefault(u => u.NationalCode == nationalCode);
                var role = context.Roles.SingleOrDefault(r => r.Name == roleName);

                if (role == null)
                {
                    appRoleManager.CreateAsync(new IdentityRole(roleName)).Wait();
                    role = context.Roles.SingleOrDefault(r => r.Name == roleName);
                }
                if (user == null)
                {
                    appUserManager.CreateAsync(new ApplicationUser(userName, nationalCode), password).Wait();
                    user = context.Users.SingleOrDefault(u => u.NationalCode == nationalCode);
                }

                var userRole = user.Roles.SingleOrDefault(r => r.RoleId == role.Id);

                if (userRole == null)
                {
                    appUserManager.AddToRoleAsync(user.Id, roleName).Wait();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}