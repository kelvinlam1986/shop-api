using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopApi.Models;

namespace ShopApi.Data
{
    public class DbSeeder
    {
        private ShopContext _dbContext;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;

        public DbSeeder(ShopContext dbContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            this._dbContext = dbContext;
            this._roleManager = roleManager;
            this._userManager = userManager;
        }

        public async Task SeedAsync()
        {
            if (await this._dbContext.Users.CountAsync() == 0)
            {
                await CreateUserAsync();
            }
        }

        private async Task CreateUserAsync()
        {
            // local variables
            DateTime createdDate = new DateTime(2016, 03, 01, 12, 30, 00);
            DateTime lastModifiedDate = DateTime.Now;
            string roleAdministrators = "Administrators";
            string roleRegistered = "Registered";

            //Create Roles (if they doesn't exist yet)
            if (!await this._roleManager.RoleExistsAsync(roleAdministrators))
            {
                await this._roleManager.CreateAsync(new IdentityRole(roleAdministrators));
            }

            if (!await this._roleManager.RoleExistsAsync(roleRegistered))
            {
                await this._roleManager.CreateAsync(new IdentityRole(roleRegistered));
            }

            // Create the "Admin" ApplicationUser account (if it doesn't exist already)
            var userAdmin = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@gmail.com"
            };

            // Insert "Admin" into the Database and also assign the "Administrator"
            // role to him.
            if (await this._userManager.FindByNameAsync(userAdmin.UserName) == null)
            {
                await this._userManager.CreateAsync(userAdmin, "12345678x@X");
                await this._userManager.AddToRoleAsync(userAdmin, roleAdministrators);
                userAdmin.EmailConfirmed = true;
                userAdmin.LockoutEnabled = true;
            }

#if DEBUG

            var userMinh = new ApplicationUser
            {
                UserName = "minhlam",
                Email = "kelvincoder@gmail.com"
            };

            if (await this._userManager.FindByNameAsync(userMinh.UserName) == null)
            {
                await this._userManager.CreateAsync(userMinh, "12345678x@X");
                await this._userManager.AddToRoleAsync(userMinh, roleRegistered);
                userMinh.EmailConfirmed = true;
                userMinh.LockoutEnabled = true;
            }

#endif
            await this._dbContext.SaveChangesAsync();
        }
    }
}