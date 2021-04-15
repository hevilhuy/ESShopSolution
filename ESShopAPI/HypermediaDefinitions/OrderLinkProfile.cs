using ESShopAPI.Models.HATEOAS;
using System.Collections.Generic;

namespace ESShopAPI.HypermediaDefinitions
{
    public class OrderLinkProfile : ILinkProfile
    {
        public List<Link> Links { get; init; }

        public OrderLinkProfile()
        {
            Links = new()
            {
                new()
                {
                    Description = "Create a new order",
                    Href = "order/create",
                    Method = "POST",
                    Model = "DeliverAddress: string, TotalPrice: double, IsDelivered: bool"
                }
            };
        }
    }
}
