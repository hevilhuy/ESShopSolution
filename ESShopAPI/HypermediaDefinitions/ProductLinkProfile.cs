using ESShopAPI.Models.HATEOAS;
using System.Collections.Generic;

namespace ESShopAPI.HypermediaDefinitions
{
    public class ProductLinkProfile : ILinkProfile
    {
        public List<Link> Links { get; init; }

        public ProductLinkProfile()
        {
            Links = new()
            {
                new()
                {
                    Description = "Create a product",
                    Href = "product/create",
                    Method = "POST",
                    Model = "Name: string, Price: double"
                },
                new()
                {
                    Description = "Update a product",
                    Href = "product/update",
                    Method = "PUT",
                    Model = "Name: string, Price: double"
                },
                new()
                {
                    Description = "Delete a product",
                    Href = "product/delete",
                    Method = "DELETE",
                    Model = "ID: int"
                },
                new()
                {
                    Description = "Get a product",
                    Href = "product/get",
                    Method = "GET",
                    Model = "ID: int"
                },
                new()
                {
                    Description = "Get product list",
                    Href = "product/list",
                    Method = "GET",
                    Model = ""
                },
                new()
                {
                    Description = "Add a product to an order",
                    Href = "product/addProductToOrder",
                    Method = "POST",
                    Model = "productId: int, orderId: int"
                }
            };
        }
    }
}
