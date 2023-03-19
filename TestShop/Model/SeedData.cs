using IXORA.PlatonovNikita.TestShop.Context;
using IXORA.PlatonovNikita.TestShop.Model.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace IXORA.PlatonovNikita.TestShop.Model
{
    public static class SeedData
    {
        public static void Seed(TestShopContext dbContext)
        {
            dbContext.Database.Migrate();
            if (!dbContext.Clients.Any())
            {
                var clients = new Client[]
                {
                    new Client
                    {
                        FullName = "Sergey Sergeyev",
                        PhoneNumber = "+79998887766"
                    },
                    new Client
                    {
                        FullName = "Ivan Ivanov",
                        PhoneNumber = "+79991112233"
                    },
                    new Client
                    {
                        FullName = "Petr Petrov",
                        PhoneNumber = "+79995554466"
                    }
                };

                dbContext.Clients.AddRange(clients);

                if (!dbContext.Products.Any())
                {
                    ProductType bicycle = new ProductType
                    {
                        NameOfType = "Bicycle"
                    };
                    ProductType motorbike = new ProductType
                    {
                        NameOfType = "Motorbike"
                    };
                    ProductType helmet = new ProductType
                    {
                        NameOfType = "Helmet"
                    };

                    Product[] products = new Product[]
                    {
                        new Product
                        {
                            Type = bicycle,
                            Name = "BMX",
                            Quantity = 10,
                            Price = 10000
                        },
                        new Product
                        {
                            Type= bicycle,
                            Name = "Merida",
                            Quantity = 13,
                            Price = 18900,
                        },
                        new Product
                        {
                            Type = motorbike,
                            Name = "Kawasaki",
                            Quantity = 5,
                            Price = 200000
                        },
                        new Product {
                            Type = motorbike,
                            Name = "BMW",
                            Quantity = 3,
                            Price = 320000
                        },
                        new Product
                        {
                            Type = helmet,
                            Name = "Carbone Helmet",
                            Quantity = 27,
                            Price = 2900
                        }
                    };

                    dbContext.AddRange(products);
                }
                dbContext.SaveChanges();
            }
        }
    }
}
