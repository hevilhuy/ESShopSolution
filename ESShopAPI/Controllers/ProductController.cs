using ESShopAPI.Filters;
using ESShopAPI.HypermediaDefinitions;
using ESShopBL;
using ESShopDAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ESShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [HATEOASFilter(typeof(ProductLinkProfile))]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("[action]")]
        public Product Get(int id)
        {
            var product = _productService.GetProduct(id);

            return product;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Product> List()
        {
            var products = _productService.GetList();

            return products;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult AddProductToOrder(int productId, int orderId)
        {
            try
            {
                _productService.AddProductToOrder(productId, orderId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }
    }
}
