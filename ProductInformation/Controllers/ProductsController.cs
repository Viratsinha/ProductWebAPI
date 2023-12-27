using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductInformation.Models;
using ProductInformation.Repositories;

namespace ProductInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id) {
            var product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound();  // here we will return 404 not found if the product is not found

            }
            return Ok(product);

        }


        [HttpGet]
        public IActionResult GetAllProduct()
        {
            var _product = _productRepository.GetAllProduct();
            return Ok(_product);

        }
        [HttpGet("byname/{productName}")]
        public IActionResult GetProductByName(string productName) { 
        var product = _productRepository.GetProductByName(productName);
            if (product == null)
            {
                return NotFound();
            }
            
            return Ok(product);
          
        }

        [HttpPost]      // ADDING NEW PRODUCTS
        public IActionResult AddProduct([FromBody] Product product) {
        
                var addProducts = _productRepository.AddProduct(product);
            /* here we are using created at action to return http 201 created
             response with a location header pointing to the newly created resource */

            /* here the new{id= addProduct.productId} creates an anonymous object containing the route 
            values of the addProduct.Id */

            return CreatedAtAction(nameof(GetProductById), new { id = addProducts.productId }, addProducts);

           
        }

        [HttpPut("{id}")]       // UPDATING THE PRODUCTS
        public IActionResult UpdateProduct(int id,[FromBody]Product updatedProduct) 
        {
            var existingproduct = _productRepository.GetProductById(id);
            if(existingproduct == null)
            {
                return NotFound();
            }
            updatedProduct.productId = id;
            var result = _productRepository.UpdateProduct(updatedProduct);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public  IActionResult DeleteProduct(int id)
        {
            var deleteProduct = _productRepository.DeleteProduct(id);
            if (deleteProduct== null)
            {
                return NotFound();
            }
            
            return Ok(deleteProduct);
            
        }

    } 
}

