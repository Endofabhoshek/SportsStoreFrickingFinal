namespace SportsStoreFrickingFinal.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SportsStoreFrickingFinal.Domain.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SportsStoreFrickingFinal.Domain.Concrete.EFDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Products.Add(new Entities.Product {
                Name = "Iron Man",
                Description = "LauhPurush",
                Price = 12,
                Category = "Iron"
            });
            context.Products.Add(new Entities.Product
            {
                Name = "AntMan",
                Description = "Dikhta Nahi hu",
                Price = 996,
                Category = "Cap"
            });
            context.Products.Add(new Entities.Product
            {
                Name = "Falcon",
                Description = "Nakli Udaan",
                Price = 233,
                Category = "Cap"
            });
            context.Products.Add(new Entities.Product
            {
                Name = "Spider Man",
                Description = "Abhi toh start kia hai!",
                Price = 17,
                Category = "Iron"
            });
            context.Products.Add(new Entities.Product
            {
                Name = "Vision",
                Description = "Muje sod do!",
                Price = 956,
                Category = "Iron"
            });
            context.Products.Add(new Entities.Product
            {
                Name = "Scarlet Witch",
                Description = "Haatho me jaadu hai!",
                Price = 36,
                Category = "Cap"
            });
            context.Products.Add(new Entities.Product
            {
                Name = "Hawk Eye",
                Description = "Teer Nishane Par",
                Price = 9945,
                Category = "Cap"
            });
            context.Products.Add(new Entities.Product
            {
                Name = "Rhodes",
                Description = "Nakli LauhPurush",
                Price = 99932,
                Category = "Iron"
            });
            context.Products.Add(new Entities.Product
            {
                Name = "Natasha",
                Description = "Kaali Widwa",
                Price = 1000,
                Category = "Neutral"
            });
            context.Products.Add(new Entities.Product
            {
                Name = "Thor",
                Description = "Hatthoda tha",
                Price = 2333,
                Category = "Neutral"
            });
        }
    }
}
