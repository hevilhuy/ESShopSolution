using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESShopAPI.Models.HATEOAS
{
    public interface ILinkProfile
    {
        List<Link> Links { get; init; }
    }
}
