using ProductInformation.Models;

namespace ProductInformation.Repositories
{
    public class ProductRepository : IProductRepository

    {
        private readonly List<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product> {

                new Product
                {
                    productId=1,
                    productName="Jeans",
                    productBrand="Levis",
                    productQuantity=1,
                    productPrice=3000
                },
                new Product
                {
                    productId=2,
                    productName="Sneakers",
                    productBrand="RedTape",
                    productQuantity=1,
                    productPrice=1400
                },
                new Product
                {
                    productId=3,
                    productName="Shirt",
                    productBrand="PeterEngland",
                    productQuantity=1,
                    productPrice=2000
                }


            };

        }
        public Product GetProductById(int Id)
        {
            return _products.FirstOrDefault(p => p.productId == Id);
        }

        public Product GetProductByName(string productName)
        {
            return _products.FirstOrDefault(p => p.productName.Equals(productName, StringComparison.OrdinalIgnoreCase));
        }

        

        public Product UpdateProduct(Product updatedProduct)
        {
            var existingProduct = _products.FirstOrDefault(p => p.productId == updatedProduct.productId);
            if (existingProduct != null)
            {
                // updating the properties based on requirements
                existingProduct.productName = updatedProduct.productName;
                existingProduct.productBrand = updatedProduct.productBrand;
                existingProduct.productPrice = updatedProduct.productPrice;
                existingProduct.productQuantity = updatedProduct.productQuantity;
            }
            return existingProduct;



        }

       

        public Product DeleteProduct(int Id)
        {
            var productToRemove = _products.FirstOrDefault(p => p.productId == Id);
            if (productToRemove != null)
            {
                _products.Remove(productToRemove);

            }
            return productToRemove;
        }

        public IEnumerable<Product> GetAllProduct()
        {
           return _products;
        }

        public Product AddProduct(Product product)
        {
            //Assigning a new id and incrementing the count by 1 since we are not using external database so we need to handle the increment of product id
            product.productId = _products.Count + 1;
            _products.Add(product);
            return product;
        }
    }
}
