using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Moq;
using ProductInformation.Controllers;
using ProductInformation.Models;
using ProductInformation.Repositories;

namespace ProductInformationTest.ProductControllerTest
{
    [TestFixture]
    public class ProductControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }
        // positive case for controller actions
        [Test]
        public void GetProductById_ShouldReturnProduct_WhenProductExists()

        {   // here the controller action is GetProductById(), positive case and it asserts that the action returns a product if the product exists

            // Arrange

            var repositoryMock = new Mock<IProductRepository>();

            repositoryMock.Setup(repo => repo.GetProductById(It.IsAny<int>()))

                   .Returns(new Product { productId = 1, productName = "Jeans" });



            var controller = new ProductsController(repositoryMock.Object);



            // Act

            var result = controller.GetProductById(1);



            // Assert

            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);



            var product = okResult.Value as Product;

            Assert.IsNotNull(product);

            Assert.AreEqual(1, product.productId);

        }

        [Test]

        public void AddProduct_ShouldReturnCreatedResponse_WhenProductIsValid()

        {
            // COntroller Action: AddProduct()
            //Positive case
            // Asserts that the action returns a created response when the product is valid

            // Arrange

            var repositoryMock = new Mock<IProductRepository>();

            repositoryMock.Setup(repo => repo.AddProduct(It.IsAny<Product>()))

                   .Returns(new Product { productId = 1, productName = "NewProduct" });



            var controller = new ProductsController(repositoryMock.Object);



            // Act

            var result = controller.AddProduct(new Product { productName = "NewProduct" });



            // Assert

            Assert.IsInstanceOf<CreatedAtActionResult>(result);

            var createdResult = result as CreatedAtActionResult;

            Assert.IsNotNull(createdResult);



            var product = createdResult.Value as Product;

            Assert.IsNotNull(product);

            Assert.AreEqual(1, product.productId);

        }

        [Test]

        public void UpdateProduct_ShouldReturnOk_WhenProductExists()

        {   //Controller ACtion: UpdateProduct
            //Positive Case
            // Asserts that the action returns Ok when updating an existing product

            // Arrange

            var repositoryMock = new Mock<IProductRepository>();

            repositoryMock.Setup(repo => repo.GetProductById(It.IsAny<int>()))

                   .Returns(new Product { productId = 1, productName = "Jeans" });



            repositoryMock.Setup(repo => repo.UpdateProduct(It.IsAny<Product>()))

                   .Returns(new Product { productId = 1, productName = "UpdatedJeans" });



            var controller = new ProductsController(repositoryMock.Object);



            // Act

            var result = controller.UpdateProduct(1, new Product { productName = "UpdatedJeans" });



            // Assert

            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);



            var updatedProduct = okResult.Value as Product;

            Assert.IsNotNull(updatedProduct);

            Assert.AreEqual(1, updatedProduct.productId);

            Assert.AreEqual("UpdatedJeans", updatedProduct.productName);

        }



        [Test]

        public void DeleteProduct_ShouldReturnOk_WhenProductExists()

        {
            //Controller Action: DeleteProduct
            // Positive Case
            // ASserts that the action returns ok when deleting an existing product

            // Arrange

            var repositoryMock = new Mock<IProductRepository>();

            repositoryMock.Setup(repo => repo.GetProductById(It.IsAny<int>()))

                   .Returns(new Product { productId = 1, productName = "Jeans" });



            repositoryMock.Setup(repo => repo.DeleteProduct(It.IsAny<int>()))

                   .Returns(new Product { productId = 1, productName = "Jeans" });



            var controller = new ProductsController(repositoryMock.Object);



            // Act

            var result = controller.DeleteProduct(1);



            // Assert

            Assert.IsInstanceOf<OkObjectResult>(result);

            var okResult = result as OkObjectResult;

            Assert.IsNotNull(okResult);



            var deletedProduct = okResult.Value as Product;

            Assert.IsNotNull(deletedProduct);

            Assert.AreEqual(1, deletedProduct.productId);

            Assert.AreEqual("Jeans", deletedProduct.productName);

        }



       



        [Test]

        public void GetProductById_ShouldReturnNotFound_WhenProductDoesNotExist()

        {
            //Controller Action: GetProductById
            //Negative Case
            //ASserts that the action returns NotFound when the product doesnot exist

            // Arrange

            var repositoryMock = new Mock<IProductRepository>();

            repositoryMock.Setup(repo => repo.GetProductById(It.IsAny<int>()))

                   .Returns((Product)null);



            var controller = new ProductsController(repositoryMock.Object);



            // Act

            var result = controller.GetProductById(1);



            // Assert

            Assert.IsInstanceOf<NotFoundResult>(result);

        }




        [Test]

        public void AddProduct_ShouldReturnBadRequest_WhenProductIsInvalid()

        {
            // Controller Action: AddProduct
            // Negative case
            // Asserts that the action returns BadRequest when the product is invalid

            // Arrange
            var repositoryMock = new Mock<IProductRepository>();

            // Adjust the setup to return BadRequestResult instead of null

            repositoryMock.Setup(repo => repo.AddProduct(It.IsAny<Product>()))
                          .Returns(new Microsoft.AspNetCore.BadRequestResult());

            var controller = new ProductsController(repositoryMock.Object);


            // Act

            var result = controller.AddProduct(new Product { productName = "InvalidProduct" });

            // Assert

            Assert.IsInstanceOf<BadRequestResult>(result);

        }

        [Test]

        public void UpdateProduct_ShouldReturnNotFound_WhenProductDoesNotExist()

        {
            //COntroller ACtion: UpdateProduct
            //Negative case
            //Asserts that the action returns NotFound when updating a non existing product

            // Arrange

            var repositoryMock = new Mock<IProductRepository>();

            repositoryMock.Setup(repo => repo.GetProductById(It.IsAny<int>()))

                   .Returns((Product)null);

            var controller = new ProductsController(repositoryMock.Object);


            // Act

            var result = controller.UpdateProduct(1, new Product { productName = "UpdatedJeans" });

            // Assert

            Assert.IsInstanceOf<NotFoundResult>(result);

        }



        [Test]

        public void DeleteProduct_ShouldReturnNotFound_WhenProductDoesNotExist()

        {
            //COntroller ACtion: DeleteProduct
            //Negative case
            //Asserts that the action returns NotFound when deleting a non existing product


            // Arrange

            var repositoryMock = new Mock<IProductRepository>();

            repositoryMock.Setup(repo => repo.GetProductById(It.IsAny<int>()))

                   .Returns((Product)null);



            var controller = new ProductsController(repositoryMock.Object);



            // Act

            var result = controller.DeleteProduct(1);



            // Assert

            Assert.IsInstanceOf<NotFoundResult>(result);

        }



    }

}


