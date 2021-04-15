using System.Collections.Generic;

namespace ESShopAPI.Models.HATEOAS
{
    public class HATEOASWrapper : ILinkProfile
    {
        public dynamic Result { get; set; }
        public List<Link> Links { get; init; }
    }
}
