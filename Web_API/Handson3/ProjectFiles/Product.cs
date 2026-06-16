namespace ProductAPI.Models
{
    public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public decimal productPrice { get; set; }
        public int productStock { get; set; }
        public string productCategory { get; set; }
        public DateTime createdDate { get; set; }
    }
}
