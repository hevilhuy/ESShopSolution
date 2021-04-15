using ESShopAPI.Filters;
using ESShopAPI.HypermediaDefinitions;
using ESShopBL;
using ESShopDAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ESShopAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [HATEOASFilter(typeof(OrderLinkProfile))]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Create(Order order)
        {
            try
            {
                _orderService.CreateOrder(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Order> List()
        {
            var orders = _orderService.GetList();

            return orders;
        }
    }
}
