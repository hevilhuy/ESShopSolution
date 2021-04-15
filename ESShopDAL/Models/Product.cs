using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESShopDAL.Models
{
    public class Product : ModelBase
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
