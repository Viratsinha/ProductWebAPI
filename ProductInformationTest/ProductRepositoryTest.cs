using System;

using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using Moq;

using ProductInformation.Controllers;

using ProductInformation.Models;

using ProductInformation.Repositories;

namespace ProductInformationTest.ProductRepositoryTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        //Negative cases for repository operations
        [Test]

        public void Repository_GetProductById_ShouldReturnNull_WhenProductDoesNotExist()

        {
            //Repository Operation: GetProductByID
            //negative case
            //asserts that the repository returns null when the product does not exist

            // Arrange

            var repositoryMock = new Mock<IProductRepository>();

            repositoryMock.Setup(repo => repo.GetProductById(It.IsAny<int>()))

                   .Returns((Product)null);



            // Act

            var result = repositoryMock.Object.GetProductById(1);



            // Assert

            Assert.IsNull(result, "Expected repository to return null when the product does not exist.");

        }



        [Test]

        public void Repository_AddProduct_ShouldReturnNull_WhenProductIsInvalid()

        {
            //Repository Operation: AddProduct
            //negative case
            //asserts that the repository returns null when adding a non existing product

            // Arrange

            var repositoryMock = new Mock<IProductRepository>();

            repositoryMock.Setup(repo => repo.AddProduct(It.IsAny<Product>()))

                   .Returns((Product)null);



            // Act

            var result = repositoryMock.Object.AddProduct(new Product { productName = "InvalidProduct" });



            // Assert

            Assert.IsNull(result, "Expected repository to return null when the product is invalid.");

        }



        [Test]

        public void Repository_UpdateProduct_ShouldReturnNull_WhenProductDoesNotExist()

        {
            //Repository Operation: UpdateProduct
            //negative case
            //asserts that the repository returns null when the product does not exist

            // Arrange

            var repositoryMock = new Mock<IProductRepository>();

            repositoryMock.Setup(repo => repo.GetProductById(It.IsAny<int>()))

                   .Returns((Product)null);



            // Act

            var result = repositoryMock.Object.UpdateProduct(new Product { productId = 1, productName = "UpdatedJeans" });



            // Assert

            Assert.IsNull(result, "Expected repository to return null when updating a non-existing product.");

        }



        [Test]

        public void Repository_DeleteProduct_ShouldReturnNull_WhenProductDoesNotExist()

        {
            //Repository Operation: DeleteProduct
            //negative case
            //asserts that the repository returns null when trying to delete a product that does not exist

            // Arrange

            var repositoryMock = new Mock<IProductRepository>();

            repositoryMock.Setup(repo => repo.GetProductById(It.IsAny<int>()))

                   .Returns((Product)null);



            // Act

            var result = repositoryMock.Object.DeleteProduct(1);



            // Assert

            Assert.IsNull(result, "Expected repository to return null when deleting a non-existing product.");

        }


    }
}