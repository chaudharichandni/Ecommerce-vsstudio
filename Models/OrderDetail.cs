namespace Ecommerce.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Product_Id { get; set;}
        public int Qty { get; set;}
        public float Rate { get; set;}
        public float Amount { get; set;}
    }
}
