using IXORA.PlatonovNikita.TestShop.Context;
using IXORA.PlatonovNikita.TestShop.Model.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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

                var sergey = new Client
                {
                    FullName = "Sergey Sergeyev",
                    PhoneNumber = "+79998887766"
                };
                var ivan = new Client
                {
                    FullName = "Ivan Ivanov",
                    PhoneNumber = "+79991112233"
                };
                var petr = new Client
                {
                    FullName = "Petr Petrov",
                    PhoneNumber = "+79995554466"
                };

                dbContext.Clients.AddRange(new[] {sergey, ivan, petr});

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


                    var bmx = new Product
                    {
                        Type = bicycle,
                        Name = "BMX",
                        Quantity = 10,
                        Price = 10000
                    };
                    var merida = new Product
                    {
                        Type = bicycle,
                        Name = "Merida",
                        Quantity = 13,
                        Price = 18900,
                    };
                    var kawasaki = new Product
                    {
                        Type = motorbike,
                        Name = "Kawasaki",
                        Quantity = 5,
                        Price = 200000
                    };
                    var bmw = new Product 
                    {
                        Type = motorbike,
                        Name = "BMW",
                        Quantity = 3,
                        Price = 320000
                    };
                    var carbonHelmet = new Product
                    {
                        Type = helmet,
                        Name = "Carbone Helmet",
                        Quantity = 27,
                        Price = 2900
                    };

                    dbContext.AddRange(new[] {bmw, merida, kawasaki, bmw, carbonHelmet});

                    if (!dbContext.Orders.Any())
                    {
                        var orders = new List<Order>()
                        {
                            new Order
                            {
                                ClientId = petr.Id,
                                OrderLines = new List<OrderLine>
                                {
                                    new OrderLine
                                    {
                                        ProductId = merida.Id,
                                        ProductQuantity = 2,
                                        ProductPrice = merida.Price,
                                    },
                                    new OrderLine
                                    {
                                        ProductId = carbonHelmet.Id,
                                        ProductQuantity = 5,
                                        ProductPrice = carbonHelmet.Price,
                                    }
                                },
                                CreatedAt = DateTime.Now
                            },
                            new Order
                            {
                                ClientId = ivan.Id,
                                OrderLines = new List<OrderLine>
                                {
                                    new OrderLine
                                    {
                                        ProductId = kawasaki.Id,
                                        ProductPrice = kawasaki.Price,
                                        ProductQuantity = 1
                                    },
                                    new OrderLine
                                    {
                                        ProductId = carbonHelmet.Id,
                                        ProductPrice = carbonHelmet.Price,
                                        ProductQuantity = 1
                                    }
                                },
                                CreatedAt= DateTime.Now
                            },
                            new Order
                            {
                                ClientId = ivan.Id,
                                OrderLines = new List<OrderLine>
                                {
                                    new OrderLine
                                    {
                                        ProductId = bmw.Id,
                                        ProductPrice = bmw.Price,
                                        ProductQuantity = 1
                                    },
                                    new OrderLine
                                    {
                                        ProductId = carbonHelmet.Id,
                                        ProductPrice = carbonHelmet.Price,
                                        ProductQuantity = 1
                                    }
                                },
                                CreatedAt = DateTime.Now
                            }
                        };
                        dbContext.Orders.AddRange(orders);
                    }
                }
                dbContext.SaveChanges();
            }
        }
    }
}
