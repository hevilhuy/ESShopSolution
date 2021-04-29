using System.Collections.Generic;

namespace ESShopDAL.Models
{
    public class Order : ModelBase
    {
        public string DeliverAddress { get; set; }
        public double TotalPrice { get; set; }
        public bool IsDelivered { get; set; }
        public ICollection<ProductLine> ProductLines { get; set; }
		public string Test { get; set; }
	}
}
