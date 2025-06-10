/*
using Microsoft.AspNetCore.Identity;

namespace HR_Manager.Data
{

    public static class DbInitializer
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole<int>> roleManager)
        {
            string[] roleNames = { "Admin", "Employee" };

            
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                   await roleManager.CreateAsync(new IdentityRole<int>(roleName));            
        }
            
        }
    }

}
*/