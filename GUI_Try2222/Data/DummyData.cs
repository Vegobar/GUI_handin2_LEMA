using GUI_Try2222.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_Try2222.Data
{
    public class DummyData
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager )
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            string adminId1 = "";
            string role1 = "Restaurant";
            string desc1 = "This is the restaurant role";

            string adminId2 = "";
            string role2 = "Kitchen";
            string desc2 = "This is the kitchen role";

            string adminId3 = "";
            string role3 = "Reception";
            string desc3 = "This is the reception role";

            string password1 = "CookFood7/";
            string password2 = "YummyFood7/";
            string password3 = "YummyFood8/";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }

            if(await roleManager.FindByNameAsync(role2) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role2, desc2, DateTime.Now));
            }

            if (await roleManager.FindByNameAsync(role3) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role3, desc3, DateTime.Now));
            }

            if (await userManager.FindByNameAsync("Kitchen@gmail.com")==null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Kitchen@gmail.com",
                    Email = "Kitchen@gmail.com",
                    Name = "Jeff",
                    Position = "Chef"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password1);
                    await userManager.AddToRoleAsync(user, role2);
                }
                adminId1 = user.Id;
            }

            if(await userManager.FindByNameAsync("Restaurant@gmail.com")==null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Restaurant@gmail.com",
                    Email = "Restaurant@gmail.com",
                    Name = "Lisa",
                    Position = "Waiter"
                };

                var result = await userManager.CreateAsync(user);
                if(result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password2);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId2 = user.Id;
            }

            if (await userManager.FindByNameAsync("Reception@gmail.com") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "Reception@gmail.com",
                    Email = "Reception@gmail.com",
                    Name = "Ove",
                    Position = "Receptionist"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password3);
                    await userManager.AddToRoleAsync(user, role3);
                }
                adminId3 = user.Id;
            }
        }
    }
}
