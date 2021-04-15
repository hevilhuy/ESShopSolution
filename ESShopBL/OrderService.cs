using ESShopDAL.EFCore;
using ESShopDAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ESShopBL
{
    public class OrderService : IService
    {
        private readonly ESShopContext _context;

        public OrderService(ESShopContext context)
        {
            _context = context;
        }

        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetList()
        {
            var orders = _context.Orders
                                        .Include(o => o.ProductLines)
                                        .ThenInclude(pl => pl.Product)
                                        .ToList();

            return orders;
        }
    }
}
