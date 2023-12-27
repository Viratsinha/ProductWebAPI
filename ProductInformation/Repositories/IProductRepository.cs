using ProductInformation.Models;

namespace ProductInformation.Repositories
{
    public interface IProductRepository
    {
        public Product GetProductById(int Id);

        public IEnumerable<Product> GetAllProduct();
        public Product GetProductByName(string productName);

        public Product AddProduct(Product product);

        public Product UpdateProduct(Product product);

        public Product DeleteProduct(int Id);
    }
}
