using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Store.Models
{
    public class StoreDbCreator : DropCreateDatabaseAlways<StoreDbContext>
    {
        protected override void Seed(StoreDbContext context)
        {
            #region Roles

            context.Roles.Add(new Role(Role.Type.User));
            context.Roles.Add(new Role(Role.Type.Admin));

            #endregion

            #region Users

            context.Users.Add(new User("Vladimir", "Strizhakov", "vova_strigh@list.ru", "gfhfdjpbr911", 2));
            context.Users.Add(new User("Ivan", "Borovets", "ivan_borovets@gmail.com", "ivanborovets", 1));

            #endregion

            #region Categories

            context.Categories.Add(new Category("Наушники"));
            context.Categories.Add(new Category("AWEI", 1));
            context.Categories.Add(new Category("Phillips", 1));

            #endregion

            #region Products

            context.Products.Add(new Product(2, "Беспроводные наушники AWEI A6200", "Blah blah blah", "123.webp", 100, 400, 9));
            context.Products.Add(new Product(2, "Наушники Phillips A89", "Blah blah blah", "123.webp", 250, 853, 3));
            context.Products.Add(new Product(2, "Наушники Phillips A89", "Blah blah blah", "123.webp", 250, 853, 3));
            context.Products.Add(new Product(3, "Беспроводные наушники AWEI Z5", "Blah blah blah", "123.webp", 179, 399, 17));

            #endregion
            
            base.Seed(context);
        }
    }
}