namespace Ecommerce.Models
{
    public class OrderMaster
    {
        public int Id { get; set; }
        public DateTime Order_date { get; set; }
        public int User_id { get; set;}
        public float Order_amount { get; set;}
    }
}
