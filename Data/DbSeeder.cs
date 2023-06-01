using Microsoft.AspNetCore.Identity;
using RoleAuthorization.Constants;
using RoleAuthorization.Models;

namespace RoleAuthorization.Data
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            //Seed Roles
            var userManager = service.GetService<UserManager<ApplicationUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Investor.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.PaymentManager.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.ServiceManager.ToString()));



            // creating admin

            var user = new ApplicationUser
            {
                UserName = "james@yjcconnect.com",
                Email = "james@yjcconnect.com",
                FirstName = "James",
                LastName = "Diaz",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null)
            {
                await userManager.CreateAsync(user, "James@123");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            }

            // create investor
            var investor = new ApplicationUser
            {
                UserName = "investor@yjcconnect.com",
                Email = "investor@yjcconnect.com",
                FirstName = "Sarah",
                LastName = "Chen",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var investorInDb = await userManager.FindByEmailAsync(investor.Email);
            if (investorInDb == null)
            {
                await userManager.CreateAsync(investor, "Investor@123");
                await userManager.AddToRoleAsync(investor, Roles.Investor.ToString().ToUpper());
            }

            // create payment manager
            var pManager = new ApplicationUser
            {
                UserName = "payment@yjcconnect.com",
                Email = "payment@yjcconnect.com",
                FirstName = "Chris",
                LastName = "Dallas",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var pmInDb = await userManager.FindByEmailAsync(pManager.Email);
            if (pmInDb == null)
            {
                await userManager.CreateAsync(pManager, "Payment@123");
                await userManager.AddToRoleAsync(pManager, Roles.PaymentManager.ToString().ToUpper());
            }

            // create service manager
            var sManager = new ApplicationUser
            {
                UserName = "service@yjcconnect.com",
                Email = "service@yjcconnect.com",
                FirstName = "Jimmy",
                LastName = "Butler",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var smInDb = await userManager.FindByEmailAsync(sManager.Email);
            if (smInDb == null)
            {
                await userManager.CreateAsync(user, "Service@123");
                await userManager.AddToRoleAsync(user, Roles.ServiceManager.ToString().ToUpper());
            }
        }

    }

}
