using Avtomoll.Abstract;
using Avtomoll.Domains;
using Avtomoll.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Avtomoll.DataAccessLayer
{
    public class DataSeeder
    {
        public static void Seed(IServiceProvider provider)
        {
            var serviceProvider = provider.GetRequiredService<IRepository<Service>>();
            var groupServiceProvider = provider.GetRequiredService<IRepository<GroupService>>();
            
            if (serviceProvider.GetList().Count() > 0)
                return;
            
            var serviceJson = new DirectoryInfo("ServicesJson").GetFiles("services.json");

            foreach (var service in serviceJson)
            {
                string categoryName = Path.GetFileName(service.FullName);
                categoryName = Path.GetFileNameWithoutExtension(categoryName);
                string jsonText = File.ReadAllText(service.FullName);
                var services = JsonConvert.DeserializeObject<List<ServiceModel>>(jsonText);

                foreach (var group in services)
                {
                    var groupService = new GroupService
                    {
                        Name = group.NameGroup
                    };

                    groupServiceProvider.Create(groupService);
                    
                    foreach (var item in group.Service)
                    {
                        var serviceItem = new Service
                        {
                            Name = item.Name,
                            NativeCar = item.NativeCar,
                            ForeignCar = item.ForeignCar,
                            LeadTime = item.LeadTime,
                            GroupService = groupService,
                        };
                        serviceProvider.Create(serviceItem);
                       
                    }
                }
            }
        }

        public static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.Users.Count() > 0) return;

            var user1 = new IdentityUser
            {
                UserName = "admin@ya.ru",
                Email = "admin@ya.ru",
                EmailConfirmed = true
            };
            IdentityResult userResult = userManager.CreateAsync(user1, "1Qwerty!").Result;
            if (userResult.Succeeded)
            {
                userResult = userManager.AddToRoleAsync(user1, "Administrator").Result;
            }

        
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = new string[]
            {
                "Administrator",
                "SalesManager",
                "ContentManager",
                "Buyer",
                "Guest"
            };
            if (roleManager.Roles.Count() > 0) return;

            foreach (var roleName in roleNames)
            {
                var role = new IdentityRole { Name = roleName };
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}