namespace Ecommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int Category_Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public float Mrp { get; set; }
        public float Rate { get; set; }
    }
}
