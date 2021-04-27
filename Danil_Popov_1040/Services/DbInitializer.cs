using Danil_Popov_1040.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Danil_Popov_1040.Services
{
    public class DbInitializer
    {
        public static async Task Seed(DAL.Data.ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)

        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();
            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            //проверка наличия групп объектов
            if (!context.DishGroups.Any())
            {
                context.DishGroups.AddRange(
                new List<DishGroup>
                {
                new DishGroup {GroupName="Стартеры"},
                new DishGroup {GroupName="Салаты"},
                new DishGroup {GroupName="Супы"},
                new DishGroup {GroupName="Основные блюда"},
                new DishGroup {GroupName="Напитки"},
                new DishGroup {GroupName="Десерты"}
                });
                await context.SaveChangesAsync();

            }
            // проверка наличия объектов
            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(
                new List<Dish>
                {
                new Dish {DishName="Грибной суп",
                Description="Лук, картофель, сливки, грибы шампиньоны.",
                Calories =180, DishGroupId=3, Image="Soup1.png" },
                new Dish {DishName="Томатный суп",
                Description="Лук, чеснок, помидоры, итальянские травы, перец",
                Calories =330, DishGroupId=3, Image="Soup2.jpg" },
                new Dish {DishName="Салат сыттов",
                Description="Фасоль, корейская морковь, сыр, сухари, зелень.",
                Calories =120, DishGroupId=4, Image="Salad.png" },
                new Dish {DishName="Салат с тунцом",
                Description="Тунец, салат, помидор. Подается в пите из пшеничной муки",
                Calories =240, DishGroupId=4, Image="Salad2.jpg" },
                new Dish {DishName="Морс Gedonia клюква",
                Description="500 мл, Вода очищенная, клюква, сахар, брусника.",
                Calories =55, DishGroupId=5, Image="Mors.png" },
                new Dish {DishName="Fanta",
                Description="500 мл, Газированный напиток со вкусом апельсина.",
                Calories =40, DishGroupId=5, Image="Fanta.png" }
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
