namespace ProductInformation.Models
{
    public class Product
    {
        public int productId { get; set; }

        public string ?productName { get; set; }
        public string ?productBrand { get; set; }
        public int productQuantity { get; set; }
        public decimal productPrice { get; set; }

    }
}
