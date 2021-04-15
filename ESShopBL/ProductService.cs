using ESShopDAL.EFCore;
using ESShopDAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ESShopBL
{
    public class ProductService : IService
    {
        private readonly ESShopContext _context;

        public ProductService(ESShopContext context)
        {
            _context = context;
        }

        public Product GetProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ID == id);

            return product;
        }

        public IEnumerable<Product> GetList()
        {
            var products = _context.Products.ToList();

            return products;
        }

        public void AddProductToOrder(int productId, int orderId)
        {
            var order = _context.Orders
                .Include(o => o.ProductLines)
                .ThenInclude(pl => pl.Product)
                .First(o => o.ID == orderId);

            var existingProductLine = _context.ProductLines.Where(pl => pl.Order.ID == orderId && pl.Product.ID == productId).FirstOrDefault();

            if (existingProductLine is not null)
            {
                existingProductLine.Quantity += 1;
            }
            else
            {
                var newProductLine = new ProductLine()
                {
                    Product = new()
                    {
                        ID = productId
                    },
                    Quantity = 1,
                    Order = order
                };

                _context.ProductLines.Add(newProductLine);
            }

            order.TotalPrice = order.ProductLines.Sum(pl => pl.Quantity * pl.Product.Price);
            _context.SaveChanges();
        }
    }
}
