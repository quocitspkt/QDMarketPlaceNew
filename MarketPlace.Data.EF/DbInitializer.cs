using MarketPlace.Data.Entities;
using MarketPlace.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<CusUser> _userManager;
        private RoleManager<CusUserRole> _roleManager;
        public DbInitializer(AppDbContext context, UserManager<CusUser> userManager, RoleManager<CusUserRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Seed()
        {
            /*if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new CusUserRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });
                await _roleManager.CreateAsync(new CusUserRole()
                {
                    Name = "Staff",
                    NormalizedName = "Staff",
                    Description = "Staff"
                });
                await _roleManager.CreateAsync(new CusUserRole()
                {
                    Name = "Customer",
                    NormalizedName = "Customer",
                    Description = "Customer"
                });
            }
            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new CusUser()
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "admin@gmail.com",

                    Status = Status.Active
                }, "123654$");
                var user = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(user, "Admin");
            }*/
        }
    }
}
