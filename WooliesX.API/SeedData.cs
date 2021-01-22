using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WooliesX.Core.Models;

namespace WooliesX.API
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await AddTestData(
                services.GetRequiredService<AppDbContext>());
        }

        private static async Task AddTestData(AppDbContext context)
        {
            context.User.Add(new User
            {
                Id = 100,
                Token = "71038a5e-4454-486a-85fb-0003a361ee7f",
                Name = "Anne McCloghry"
            });

            var product1 = new Product
            {
                Id = 1,
                Name = "Test Product A",
                Price = 99.99,
                Quantity = 0
            };
            context.Add(product1);
            var product2 = new Product
            {
                Id = 2,
                Name = "Test Product B",
                Price = 101.99,
                Quantity = 0
            };
            context.Add(product2);
            var product3 = new Product
            {
                Id = 3,
                Name = "Test Product C",
                Price = 10.99,
                Quantity = 0
            };
            context.Add(product3);
            var product4 = new Product
            {
                Id = 4,
                Name = "Test Product D",
                Price = 5,
                Quantity = 0
            };
            context.Add(product4);
            var product5 = new Product
            {
                Id = 5,
                Name = "Test Product F",
                Price = 999999999999,
                Quantity = 0
            };
            context.Add(product5);


            /////
            //product1.Quantity = 3;
            //product2.Quantity = 1;
            //product3.Quantity = 1;
            //var prodArr = new Product[] { product1, product2, product3 };
            context.Add(new ShopperHistory
            {
                Id = 1,
                CustomerId = 123,
                Products = new List<Product>
                {
                    new Product{ Id = 10, Name = "Product G", Quantity = 3},
                    new Product{ Id = 10, Name = "Product H", Quantity = 2},
                    new Product{ Id = 10, Name = "Product I", Quantity = 1},
                }
            });

            //product1.Quantity = 2;
            //product2.Quantity = 3;
            //product3.Quantity = 1;
            context.Add(new ShopperHistory
            {
                Id = 2,
                CustomerId = 123//,
               // Products = prodArr.ToList()
            });

            context.Add(new ShopperHistory
            {
                Id = 3,
                CustomerId = 23//,
               // Products = prodArr.ToList()
            });

            context.Add(new ShopperHistory
            {
                Id = 4,
                CustomerId = 123//,
             //   Products = prodArr.ToList()
            });


            await context.SaveChangesAsync();
        }
    }
}
