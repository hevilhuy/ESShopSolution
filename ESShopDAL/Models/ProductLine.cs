namespace ESShopDAL.Models
{
    public class ProductLine : ModelBase
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
    }
}
