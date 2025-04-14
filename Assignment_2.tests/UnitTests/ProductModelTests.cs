using Xunit;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Assignment_1.Models;


namespace Assignment_2.Models
{
    public class ProductModelTests
    {
        [Fact]
        public void ProductName_ShouldNotBeEmpty()
        {
            // Arrange
            var product = new Products { Name = "" };

            // Act
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(product, new ValidationContext(product), results, true);

            // Assert
            Assert.False(isValid); // Validation should fail
            Assert.Contains(results, r => r.ErrorMessage == "The Name field is required.");
        }

        [Fact]
        public void ProductPrice_ShouldBePositive()
        {
            // Arrange
            var product = new Products { Price = -5 };
        }
    }

}



