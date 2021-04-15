using ESShopDAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESShopDAL.EFCore
{
    public static class DbInitializer
    {
        public static async Task Initialize(ESShopContext context)
        {
            context.Database.EnsureCreated();
            await InitProduct(context);
            await InitOrder(context);
            await InitProductLine(context);
        }

        private static async Task InitOrder(ESShopContext context)
        {
            if (!context.Orders.Any())
            {
                var order = new Order()
                {
                    DeliverAddress = "Test address",
                    IsDelivered = false,
                    TotalPrice = 1400d
                };

                context.Orders.Add(order);
                await context.SaveChangesAsync();
            }
        }

        private static async Task InitProductLine(ESShopContext context)
        {
            var firstProduct = await context.Products.FirstOrDefaultAsync();
            var firstOrder = await context.Orders.FirstOrDefaultAsync();

            if (!context.ProductLines.Any())
            {
                var productLineList = new List<ProductLine>()
                {
                    new()
                    {
                        Product = firstProduct,
                        Quantity = 10,
                        Order = firstOrder
                    },
                    new()
                    {
                        Product = firstProduct,
                        Quantity = 2,
                        Order = firstOrder
                    }
                };

                context.ProductLines.AddRange(productLineList);
                await context.SaveChangesAsync();
            }
        }

        private static async Task InitProduct(ESShopContext context)
        {
            if (!context.Products.Any())
            {
                var productList = new List<Product>()
                {
                    new ()
                    {
                        Name = "Product 1",
                        Price = 45d
                    },
                    new ()
                    {
                        Name = "Product 2",
                        Price = 25d
                    }
                };

                context.Products.AddRange(productList);
                await context.SaveChangesAsync();
            }
        }
    }
}
